import React, { useContext, useEffect, useState } from 'react'
import { useFormik } from 'formik'
import AuthContext from '../../api/context/AuthContext'
import { Button, Form, InputGroup } from 'react-bootstrap'
import { useNavigate, useParams } from 'react-router-dom'
import OfferService from '../../api/services/OfferService'
import { toast } from 'react-toastify'
import ProductService from '../../api/services/ProductService'
import offerSchema from '../../validations/OfferValidation'

function OfferWithPercent() {

    const { user } = useContext(AuthContext)
    const { productId } = useParams()
    const offerService = new OfferService()
    const productService = new ProductService()
    const token = localStorage.getItem("token")
    const [product, setProduct] = useState({})
    const [percentPrice,setPercentPrice] = useState(0)
    const navigate = useNavigate()

    const getProduct = async () => {
        try {
            let result = await productService.getProductById(productId)
            setProduct(result.data.data)
        } catch (error) {
            console.log(error)
        }
    }
    
    useEffect(() => {
        getProduct()
    }, [productId])

    const formik = useFormik({
        initialValues: {
            productId: 0,
            userId: 0,
            offeredPrice: 0
        },
        onSubmit: async (values) => {
            try {
                values.productId = productId
                values.userId = user.userId
                values.offeredPrice = product.price*(formik.values.offeredPrice/100)
                await offerService.add(values,token)
                toast.success("Successfully Offered !")
                navigate("/myoffers")
            } catch (error) {
                console.log(token)
                console.log(error)
                toast.error("Error")
            }
        },
        validationSchema:offerSchema
    })

    const handlePercentPrice=()=>{
        setPercentPrice(product.price*(formik.values.offeredPrice/100))
    }
    useEffect(()=>{
        handlePercentPrice()
    },[formik.values.offeredPrice])

    return (
        <div>
            <hr />
            <h4>With Percent</h4>
            <form onSubmit={formik.handleSubmit}>
                <InputGroup className="mb-3">
                <InputGroup.Text className='inputGroup-sizing-lg' >%</InputGroup.Text>
                <Form.Control
                    size='lg'
                    placeholder='Offered Price'
                    autoComplete='off'
                    value={formik.values.offeredPrice}
                    name="offeredPrice"
                    onChange={formik.handleChange}
                    onBlur={formik.handleBlur}
                    type='number'
                />
                </InputGroup>   
                {formik.errors.offeredPrice && formik.touched.offeredPrice && formik.errors.offeredPrice}
                <br />
                <Button type='submit' size='lg'>Offer</Button>
                
                <h3>You Will Offer :{percentPrice} $</h3>
            </form>
        </div>
    )
}

export default OfferWithPercent