import { useEffect } from 'react'
import { useFormik } from 'formik'
import { Button } from 'react-bootstrap';
import Form from 'react-bootstrap/Form';
import {toast} from 'react-toastify'
import CategoryService from '../../api/services/CategoryService';
import { useState } from 'react';
import { useParams } from 'react-router-dom';
import { useContext } from 'react';
import CategoryContext from '../../api/context/CategoryContext';
import  categorySchema  from '../../validations/CategoryValidation';

function UpdateCategory() {
    const categoryService = new CategoryService()
    const token = localStorage.getItem("token")
    const {getData} = useContext(CategoryContext)
    const {categoryId} = useParams()
    const [category,setCategory] = useState({})
    const getCategory=async()=>{
        try {
            let result = await categoryService.getCategoryById(categoryId)
            setCategory(result.data.data)
        } catch (error) {
            console.log(error)
        }
    }

    useEffect(()=>{
        getCategory()
    },[category])

    const formik = useFormik({
        initialValues: {
            categoryId:0,
            name: ""
        },
        onSubmit: async(values) => {
           try {
            values.categoryId=categoryId
            await categoryService.update(values,token)
            toast.success("Category Updated!",{
                position:'top-right'
            })
            getData()
           } catch (error) {
            toast.error("Error! Category not Updated",{
                position:'top-right'
            })
           }
        },
        validationSchema:categorySchema
    })

  return (
    <div>
         <h4>Update Category : {category.name}</h4>
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
                <Button type='submit' size='lg'>Update</Button>
            </form>
    </div>
  )
}

export default UpdateCategory