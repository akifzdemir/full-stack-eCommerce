import React, { useContext, useEffect, useState } from 'react'
import AuthContext from '../../api/context/AuthContext'
import ProductService from '../../api/services/ProductService'
import Table from 'react-bootstrap/Table';
import { Button,Stack } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { toast } from 'react-toastify';

function UserProducts() {

    const { user } = useContext(AuthContext)
    const [products, setProducts] = useState([])
    const productService = new ProductService()

    const handleDelete=async(product)=>{
        try {
            await productService.deleteProduct(product)
            toast.success("Product Deleted")
            getData()
        } catch (error) {
            console.log(error)
            toast.error("Error")
        }
    }

    const getData = async () => {
        try {
            let result = await productService.getUserProducts(user.userId)
            setProducts(result.data.data)
        } catch (error) {
            console.log(error)
        }
    }
    useEffect(() => {
        getData()
    }, [user])

    return (
        <div>
            {
                products.length === 0 ?
                    <Stack direction='horizantal' className="col-md-6 mx-auto" gap={3}>
                        <h2 className="mt-3 text-center">You don't have any Product</h2>
                        <Button as={Link} to="/addproduct">Post Product</Button>
                    </Stack>
                    :
                    <>
                    <h1>My Products</h1>
                     <Table striped bordered hover>
                        <thead>
                            <tr style={{ textAlign: 'center' }}>
                                <th><h4>Product Name</h4></th>
                                <th><h4>Is Sold</h4></th>
                                <th><h4>Is Offerable</h4></th>
                                <th><h4>See Offers</h4></th>
                                <th><h4>Delete</h4></th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                products.map(product => (
                                    <tr key={product.productId} style={{ textAlign: 'center' }}>
                                        <td><h4>{product.productName}</h4></td>
                                        <td><h4>{String(product.isSold)}</h4></td>
                                        <td><h4>{String(product.isOfferable)}</h4></td>
                                        <td><Button as={Link} to={`/myproducts/offers/${product.productId}`} style={{ width: "100%" }}>See Offers</Button></td>
                                        <td><Button onClick={()=>handleDelete(product)} variant='danger'>Delete</Button></td>
                                    </tr>
                                ))
                            }
                        </tbody>
                    </Table>
                    </>
                   
            }

        </div>
    )
}

export default UserProducts