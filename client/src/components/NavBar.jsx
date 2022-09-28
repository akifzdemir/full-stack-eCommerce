import { Button,Stack } from 'react-bootstrap';
import React, { useContext } from 'react'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import {Link, useNavigate} from 'react-router-dom'
import AuthContext from '../api/context/AuthContext';
import { toast } from 'react-toastify';

function NavBar() {

  const {auth,user,setUser,setAuth} = useContext(AuthContext)
  const navigate = useNavigate()
  const logout=async()=>{
    try {
      localStorage.removeItem("token")
      setAuth(false)
      setUser({userId:0,userName:""})
      toast.success("Successfully Logged out",{
        position:'top-center'
      })
      navigate("/")
    } catch (error) {
      console.log(error)
    } 
  }

  return (
    <>
     <Navbar bg="dark" variant="dark">
        <Container>
          <Navbar.Brand as={Link} to="/" >Product Catalog Project</Navbar.Brand>
          <Nav className="me-auto">
            <Nav.Link active as={Link} to="/categories">Edit Categories</Nav.Link>  
            <Nav.Link as={Link} to="/addproduct" active>Post Product</Nav.Link>
          </Nav>
          <Nav>
            {
              auth==false ? <Stack direction='horizontal' gap={3}>
               <Button as={Link} to='/login'>Login</Button>
              <Button as={Link} to='/register'>Register</Button>
               </Stack>   :
              <Stack direction='horizontal' gap={3}>
                <Nav.Link active as={Link} to={"/myproducts"}>My Products</Nav.Link>
                <Nav.Link active as={Link} to={"/myoffers"}>My Offers</Nav.Link>
                <Navbar.Text>
               Logged in as: {user.userName}
              </Navbar.Text>
              <Button onClick={()=>logout()}>Log Out</Button>
            </Stack>       
            }      
          </Nav>
        </Container>
      </Navbar>
    </>
  )
}

export default NavBar