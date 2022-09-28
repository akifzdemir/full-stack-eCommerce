import React, { useContext, useEffect, useState } from 'react'
import { useFormik } from 'formik'
import AuthContext from '../../api/context/AuthContext'
import { Button, Form } from 'react-bootstrap'
import { useNavigate, useParams } from 'react-router-dom'
import OfferService from '../../api/services/OfferService'
import { toast } from 'react-toastify'
import ProductService from '../../api/services/ProductService'
import {Link} from 'react-router-dom'
import offerSchema from '../../validations/OfferValidation'

function OfferToProduct() {

    const { user } = useContext(AuthContext)
    const { productId } = useParams()
    const offerService = new OfferService()
    const productService = new ProductService()
    const token = localStorage.getItem("token")
    const [product,setProduct] = useState({})
    const navigate = useNavigate()

    const getProduct=async()=>{
        try {
          let result = await productService.getProductById(productId)
          setProduct(result.data.data)
        } catch (error) {
          console.log(error)
        }
      }
      useEffect(()=>{
        getProduct()
      },[productId])

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

    return (
        <div>
            <h4>Make A Offer to:{product.productName}</h4>
            <form onSubmit={formik.handleSubmit}>
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
                {formik.errors.offeredPrice && formik.touched.offeredPrice && formik.errors.offeredPrice}
                <br />
                <Button type='submit' size='lg'>Offer</Button>
            </form>
            <h2>Or</h2>
            <Button as={Link} to={`/offerwithpercent/${productId}`} size='lg'>Offer With Percent</Button>
            <br />
        </div>
    )
}

export default OfferToProduct