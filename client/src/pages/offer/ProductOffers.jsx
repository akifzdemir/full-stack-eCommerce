import {useEffect, useState } from 'react'
import OfferService from '../../api/services/OfferService'
import {Button,Table} from 'react-bootstrap'
import ProductService from '../../api/services/ProductService'
import {useParams,Link} from 'react-router-dom'
import { toast } from 'react-toastify'

export default function ProductOffers() {

  const offerService = new OfferService()
  const productService = new ProductService()
  const [offers,setOffers]=useState([])
  const [product,setProduct]=useState({})
  const {productId} = useParams()
  const token = localStorage.getItem("token")


  const getProduct=async()=>{
    try {
      let result = await productService.getProductById(productId)
      setProduct(result.data.data)
    } catch (error) {
      console.log(error)
    }
  }
  const handleAccept=async(offerId)=>{
    const accept = true
    try {
      await offerService.updateIsAccepted(offerId,accept)
      toast.success("Offer Accepted")
      getData()
    } catch (error) {
      console.log(error)
      toast.error("Error")
    }
  }

  const getData=async()=>{
    try {
      let result = await offerService.getOfferDetailsByProduct(productId,token)
      setOffers(result.data.data)
    } catch (error) {
     console.log(error) 
    }
  }

  useEffect(()=>{
    getData()
    getProduct()
  },[productId])

  return (
    <div>
      <h2>Product:{product.productName}</h2>
           <Table striped bordered hover>
                <thead>
                    <tr style={{ textAlign: 'center' }}>
                        <th><h4>Offered Price</h4></th>
                        <th><h4>User Name</h4></th>
                        <th><h4>Is Accepted</h4></th>
                        <th><h4>Accept</h4></th>
                    </tr>
                </thead>
                <tbody>
                    {
                        offers.map(offer => (
                            <tr key={offer.offerId} style={{ textAlign: 'center' }}>
                                <td><h4>{offer.offeredPrice}</h4></td>
                                <td><h4>{offer.userName}</h4></td>
                                <td><h4>{String(offer.isAccepted)}</h4></td>
                                <td><Button disabled={offer.isAccepted ? true:false} onClick={()=>{handleAccept(offer.offerId)}} style={{width:"100%"}}>Accept</Button></td>
                            </tr>
                        ))
                    }
                </tbody>
            </Table>
    </div>
  )
}
