import React, { useContext ,useEffect} from 'react'
import Table from 'react-bootstrap/Table';
import { Button } from 'react-bootstrap'
import CategoryContext from '../../api/context/CategoryContext';
import CategoryService from '../../api/services/CategoryService';
import { toast } from 'react-toastify';
import {Link} from 'react-router-dom'

function Categories() {

    const {categories,getData} = useContext(CategoryContext)
    const categoryService = new CategoryService()
    const token = localStorage.getItem("token")
    const handleDelete=async(category)=>{
        try {
            await categoryService.delete(category,token)
            getData()
            toast.success("Category Deleted !",{
                position:'top-right'
            })
        } catch (error) {
            toast.error("Category Not Deleted",{
                position:'top-right'
            })
        }
    }

  return (
    <div>
       <Table striped bordered hover>
    <thead>
      <tr style={{textAlign:'center'}}>
        <th><h4>Name</h4></th>
        <th><h4>Update</h4></th>
        <th><h4>Delete</h4></th>
      </tr>
    </thead>
    <tbody>
      {
        categories.map((category) => (
          <tr key={category.categoryId} style={{textAlign:'center'}}> 
            <td><h5>{category.name}</h5></td>
            <td><Button as={Link} to={`/updatecategory/${category.categoryId}`} style={{width:"100%"}}>Update</Button></td>
            <td><Button onClick={()=>handleDelete(category)} style={{width:"100%"}}variant='danger'>Delete</Button></td>
          </tr>
        ))
      }
    </tbody>
    
  </Table>
  <br />
  <Button as={Link} to="/addcategory">Add Category</Button>
    </div>
   
  
  )
}

export default Categories