import React, { useContext,useEffect } from 'react'
import { Col, Row, Stack, Button,Card,ListGroup  } from 'react-bootstrap';
import { Link, useParams } from 'react-router-dom';
import { toast } from 'react-toastify';
import ProductContext from '../../api/context/ProductContext';
import { imageUrl } from '../../api/ApiUrl';
import ProductService from '../../api/services/ProductService';
function ProductList() {

  const { products,setProducts ,getData,handleBuy,buyButton} = useContext(ProductContext)
  
  const {categoryId} = useParams()
  const productService = new ProductService()

  const getProducts=async()=>{
    try {
      if (categoryId) {
        let result = await productService.getProductDetailsByCategory(categoryId)
        setProducts(result.data.data)
      }else{
        getData()
      }
    } catch (error) {
      console.log(error)
    }
  }
  useEffect(()=>{
    getProducts()
  },[categoryId,buyButton])

  return (
   <>
    <Row>
      {
        products.map((product) => (
          <Col key={product.productId} xs={4}>
            <Card style={{ width: '18rem' }}>
              <Card.Img  style={{maxHeight:'17em'}} variant="top" src={imageUrl + product.imagePath} />
              <Card.Body>
              <Card.Title>{product.productName}</Card.Title>
              <Card.Text style={{maxHeight:'1.5em',overflow:'hidden'}}>
                {product.description}
              </Card.Text>
              </Card.Body>
                <ListGroup className="list-group-flush">
                  <ListGroup.Item>Price: {product.price}$</ListGroup.Item>
                  <ListGroup.Item>Category:{product.categoryName}</ListGroup.Item>
                </ListGroup>
                <Card.Body>
                <Stack direction='horizontal' gap={3}>
                  {product.isSold===false ? 
                  <Button onClick={()=>{handleBuy(product.productId,product.price);}} style={{ width: '5em' }} variant="success">Buy</Button>:
                  <Button disabled style={{ width: '5em' }} variant="danger">Sold</Button>
                  }
                  {
                    product.isOfferable && product.isSold===false ?
                    <Button as={Link} to={`/offer/${product.productId}`}>Offer</Button>
                    :
                    <Button disabled>Not Offerable</Button>
                  }
                  <Button as={Link} to={`/product/${product.productId}`} variant='secondary' style={{ width: '5em' }}>See Details</Button>
                </Stack>
                </Card.Body>
            </Card>
            <br />
          </Col>
        ))
      }
   </Row>
   </>
  )
}

export default ProductList