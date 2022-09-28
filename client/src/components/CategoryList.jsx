import React, { useContext,useEffect } from 'react'
import ListGroup from 'react-bootstrap/ListGroup';
import { Link } from 'react-router-dom';
import CategoryContext from '../api/context/CategoryContext';


function CategoryList() {
  
  const {categories} = useContext(CategoryContext)


  return (
    <ListGroup as="ul">
      <ListGroup.Item style={{backgroundColor:"#212529"}} active>
       Categories
      </ListGroup.Item>
      <ListGroup.Item as={Link} to={"/"}>
        All
      </ListGroup.Item>
      {
        categories.map((category)=>(
           <ListGroup.Item as={Link} to={`/${category.categoryId}`} key={category.categoryId}>{category.name}</ListGroup.Item>
        ))
       
      }
     
    </ListGroup>
  )
}

export default CategoryList