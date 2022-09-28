import React, { useState } from 'react'
import { useContext } from 'react'
import { useEffect } from 'react'
import { Col, Badge, Figure, Row, Card, Button, Stack } from 'react-bootstrap'
import { useParams } from 'react-router-dom'
import { toast } from 'react-toastify'
import { imageUrl } from '../../api/ApiUrl'
import ProductContext from '../../api/context/ProductContext'
import ProductService from '../../api/services/ProductService'
import { Link } from 'react-router-dom'

function ProductDetail() {

    const [product, setProduct] = useState({})
    const productService = new ProductService();
    const { productId } = useParams()
    const { handleBuy, buyButton } = useContext(ProductContext)


    const getProduct = async () => {
        try {
            let result = await productService.getProductDetailById(productId)
            setProduct(result.data.data[0])
            console.log(result)
        } catch (error) {
            console.log(error)
        }
    }

    useEffect(() => {
        getProduct()
    }, [productId, buyButton])

    return (
        <div>
            <Row>
                <Col md={4}>
                    <Figure>
                        <Figure.Image
                            src={imageUrl + product.imagePath}
                            width={360}
                        />
                    </Figure>
                </Col>
                <Col md={8}>
                    <Card>
                        <Card.Header as={'h2'}>{product.productName}</Card.Header>
                        <Card.Body>
                            <Card.Title>Price: {product.price}$</Card.Title>
                            <Card.Text>
                                Description:
                                {product.description}
                            </Card.Text>
                            <hr />
                            <Card.Text>
                                <Badge style={{ fontSize: "1.0em" }} bg="dark">Owner Name :</Badge> {product.userName}
                            </Card.Text>
                            <Card.Text>
                                <Badge style={{ fontSize: "1.0em" }} bg="dark">Category :</Badge> {product.categoryName}
                            </Card.Text>
                            <Card.Text>
                                <Badge style={{ fontSize: "1.0em" }} bg="dark">Color :</Badge>   {product.colorName}
                            </Card.Text>
                            <Card.Text>
                                <Badge style={{ fontSize: "1.0em" }} bg="dark">Brand :</Badge>   {product.brandName}
                            </Card.Text>
                            <Card.Text>
                                <Badge style={{ fontSize: "1.0em" }} bg="dark">Using Statuses :</Badge>   {product.usingStatusName}
                            </Card.Text>
                            <Stack direction='horizantal' gap={3}>
                                {product.isSold === false?
                                    <Button onClick={() => { handleBuy(product.productId, product.price); }} variant="success">Buy</Button>
                                    :
                                    <Button disabled  variant="danger">Sold</Button>
                                }
                                {
                                    product.isOfferable && product.isSold === false ?
                                        <Button as={Link} to={`/offer/${productId}`}>Offer</Button>
                                        :
                                        <Button disabled>Not Offerable</Button>
                                }

                            </Stack>

                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        </div>
    )
}

export default ProductDetail