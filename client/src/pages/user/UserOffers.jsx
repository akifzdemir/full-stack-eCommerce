import React, { useContext, useEffect, useState } from 'react'
import { toast } from 'react-toastify'
import AuthContext from '../../api/context/AuthContext'
import OfferService from '../../api/services/OfferService'
import { Table, Button, Stack } from 'react-bootstrap';
import ProductContext from '../../api/context/ProductContext';
import { Link } from 'react-router-dom'


function UserOffers() {
  const offerService = new OfferService()
  const [offers, setOffers] = useState([])
  const { user } = useContext(AuthContext)
  const { handleBuy, buyButton } = useContext(ProductContext)
  const token = localStorage.getItem("token")

  const handleDelete = async (offer) => {
    try {
      await offerService.delete(offer, token)
      toast.success("Offer Deleted")
      getData()
    } catch (error) {
      console.log(error)
      toast.error("Error")
    }
  }

  const getData = async () => {
    try {
      if (token) {
        let result = await offerService.getOfferDetailsByUser(user.userId)
        setOffers(result.data.data)
      } else {
        toast.error("You need to Login")
      }
    } catch (error) {
      console.log(error.message)
    }
  }
  useEffect(() => {
    console.log(user)
    getData()
  }, [user, buyButton])

  return (
    <div>
      {offers.length === 0 ?
        <Stack direction='horizantal' className="col-md-6 mx-auto" gap={3}>
          <h2 className="mt-3 text-center">You don't have any Offer</h2>
          <Button as={Link} to="/">Make Offer</Button>
        </Stack>
        :
        <>
        <h1>My Offers</h1>
          <Table striped bordered hover>
            <thead>
              <tr style={{ textAlign: 'center' }}>
                <th><h4>Offered Price</h4></th>
                <th><h4>Is Accepted</h4></th>
                <th><h4>Offered Product Name</h4></th>
                <th><h4>Delete</h4></th>
                <th><h4>Update</h4></th>
                <th><h4>Buy</h4></th>
              </tr>
            </thead>
            <tbody>
              {
                offers.map((offer) => (
                  <tr key={offer.offerId} style={{ textAlign: 'center' }}>
                    <td><h5>{offer.offeredPrice}</h5></td>
                    <td><h5>{offer.isAccepted == false ? "Waiting" : "Accepted"}</h5></td>
                    <td><h5>{offer.productName}</h5></td>
                    <td><Button onClick={() => { handleDelete(offer) }} style={{ width: "100%" }} variant='danger'>Delete</Button></td>
                    <td><Button as={Link} to={`/myoffers/update/${offer.offerId}`}>Update</Button></td>
                    <td>{offer.isAccepted ?
                      <Button onClick={() => { handleBuy(offer.productId, offer.offeredPrice) }} disabled={offer.isSold == false ? false : true} style={{ width: "100%" }} variant='success'>{offer.isSold === false ? "Buy" : "Sold"}</Button>
                      : <Button disabled>Buy</Button>}</td>
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

export default UserOffers
