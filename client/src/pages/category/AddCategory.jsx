import { useFormik } from 'formik'
import React from 'react'
import { Button } from 'react-bootstrap';
import Form from 'react-bootstrap/Form';
import {toast} from 'react-toastify'
import CategoryService from '../../api/services/CategoryService';
import { useContext } from 'react';
import CategoryContext from '../../api/context/CategoryContext';
import  categorySchema  from '../../validations/CategoryValidation';
import { useNavigate } from 'react-router-dom';


function AddCategory() {
    const categoryService = new CategoryService()
    const {getData} = useContext(CategoryContext)
    const token = localStorage.getItem("token")
    const navigate = useNavigate()
    
    const formik = useFormik({
        initialValues: {
            name: ""
        },
        onSubmit: async(values) => {
           try {
            await categoryService.add(values,token)
            toast.success("Category Added!",{
                position:'top-right'
            })
            navigate("/categories")
            getData();
           } catch (error) {
            toast.error("Error! Category not Added",{
                position:'top-right'
            })
           }
        },
        validationSchema:categorySchema
    })

    return (
        <div>
            <h4>Add Category</h4>
            <form onSubmit={formik.handleSubmit}>
                <Form.Control
                    size='lg'
                    placeholder='Category Name'
                    autoComplete='off'
                    value={formik.values.name}
                    name="name"
                    onChange={formik.handleChange}
                    onBlur={formik.handleBlur}
                    type='text'
                />
                {formik.errors.name && formik.touched.name && formik.errors.name}
                <br />
                <Button type='submit' size='lg'>Add</Button>
            </form>
        </div>
    )
}

export default AddCategory