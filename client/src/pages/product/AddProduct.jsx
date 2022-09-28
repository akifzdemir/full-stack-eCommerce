import React, { useContext, useState } from 'react'
import { useFormik } from 'formik'
import CategoryContext from '../../api/context/CategoryContext'
import ColorContext from '../../api/context/ColorContext'
import Form from 'react-bootstrap/Form';
import { Button, Container, Row, Col} from 'react-bootstrap';
import ProductService from '../../api/services/ProductService';
import BrandContext from '../../api/context/BrandContext';
import UsingStatusContext from '../../api/context/UsingStatusContext';
import ProductImageService from '../../api/services/ProductImageService';
import { toast } from 'react-toastify'
import AuthContext from '../../api/context/AuthContext';
import productSchema from '../../validations/ProductValidation';
import { useNavigate } from 'react-router-dom';

function AddProduct() {

    const [file, setFile] = useState()
    const { categories } = useContext(CategoryContext)
    const { colors } = useContext(ColorContext)
    const { brands } = useContext(BrandContext)
    const { usingStatuses } = useContext(UsingStatusContext)
    const productService = new ProductService()
    const productImageService = new ProductImageService()
    const { user } = useContext(AuthContext)
    const token = localStorage.getItem("token")
    const navigate = useNavigate()

    function handleImageChange(event) {
        setFile(event.target.files[0])
    }

  const isFileValid = (file)=> {
        if(file.type.match('image/jpeg') || file.type.match('image/jpg') || file.type.match('image/png') && file.size <409600){
            return true
        }else{
            return false
        } 
      }
    const config = {
        headers: {
            'content-type': 'multipart/form-data',
        }
    }

    const formik = useFormik({
        initialValues: {
            userId: user.userId,
            categoryId: 0,
            colorId: 0,
            usingStatusId: 0,
            brandId: 0,
            price: 0,
            isOfferable: false,
            isSold: false,
            productName: "",
            description: ""

        },
        onSubmit: async (values) => {
            try {
                const formData = new FormData();
                if (isFileValid(file)) {
                    let result = await productService.addProduct(values, token)
                    formData.append('file', file);
                    formData.append('productId', result.data.message);
                    await productImageService.addImage(formData, config)
                    toast.success("Product Added ! ", {
                        position: "top-right"
                    })
                    navigate("/")
                }else{
                    toast.error("File Not Valid !")
                }
            } catch (error) {
                console.log(values)
                console.log(error)
                toast.error("Product Not Added ! ", {
                    position: "top-right"
                })
            }
        },
        validationSchema: productSchema
    })

    return (
        <div>
            <Container>
                <h3>Add Product</h3>
                <form onSubmit={formik.handleSubmit}>
                    <Form.Label>Product Name</Form.Label>
                    <Form.Control
                        autoComplete='off'
                        type="text"
                        name="productName"
                        placeholder="Enter Product Name"
                        onChange={formik.handleChange}
                        onBlur={formik.handleBlur}
                        value={formik.values.productName}
                    />
                    {formik.errors.productName && formik.touched.productName && formik.errors.productName}
                    <br />
                    <Row className="mb-3">
                        <Col>
                            <Form.Label>Color</Form.Label>
                            <Form.Select name="colorId" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.colorId}>
                                <option value={null}>Select Color</option>
                                {
                                    colors.map(color => (
                                        <option value={color.colorId}>{color.name}</option>
                                    ))
                                }
                            </Form.Select>

                        </Col>

                        <br />
                        <Col>
                            <Form.Label>Brand</Form.Label>
                            <Form.Select name="brandId" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.brandId}>
                                <option  value={null}>Select Brand</option>
                                {
                                    brands.map(brand => (
                                        <option value={brand.brandId}>{brand.name}</option>
                                    ))
                                }
                            </Form.Select>

                        </Col>
                    </Row>

                    <Row>
                        <Col>
                            <Form.Label>Category</Form.Label>
                            <Form.Select name="categoryId" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.categoryId}>
                                <option value={null}>Select Category</option>
                                {
                                    categories.map(category => (
                                        <option value={category.categoryId}>{category.name}</option>
                                    ))
                                }
                            </Form.Select>
                            {formik.errors.categoryId && formik.touched.categoryId && formik.errors.categoryId}
                        </Col>

                        <Col>
                            <Form.Label>Using Status</Form.Label>
                            <Form.Select name="usingStatusId" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.usingStatusId}>
                                <option  value={null}>Select Using Status</option>
                                {
                                    usingStatuses.map(usingStatus => (
                                        <option value={usingStatus.usingStatusId}>{usingStatus.name}</option>
                                    ))
                                }
                            </Form.Select>
                            {formik.errors.usingStatusId && formik.touched.usingStatusId && formik.errors.usingStatusId}
                        </Col>
                    </Row>
                    <br />
                    <Form.Label>Price</Form.Label>
                    <Form.Control name="price" type='number' onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.price} />
                    {formik.errors.price && formik.touched.price && formik.errors.price}
                    <br />
                    <Form.Label>Description</Form.Label>
                    <Form.Control name="description" onChange={formik.handleChange} onBlur={formik.handleBlur} value={formik.values.description} as="textarea" rows={3} />
                    {formik.errors.description && formik.touched.description && formik.errors.description}
                    <br />
                    <Row>
                        <Col>
                            <Form.Label>Product Image</Form.Label>
                            <Form.Control onChange={handleImageChange} required type="file" />
                        </Col>

                        <Col>
                            <Form.Check
                                name="isOfferable"
                                value={formik.values.isOfferable}
                                onChange={formik.handleChange}
                                onBlur={formik.handleBlur}
                                type="switch"
                                style={{ fontSize: "1.5em" }}
                                id="custom-switch"
                                label={`Is Offerable : ${formik.values.isOfferable}`}
                            />
                            {formik.errors.isOfferable && formik.touched.isOfferable && formik.errors.isOfferable}
                        </Col>
                    </Row>
                    <br />
                    <Button style={{ fontSize: "1.2em" }} type="submit">Submit</Button>
                </form>
            </Container>
        </div>
    )
}

export default AddProduct