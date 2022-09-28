import { useFormik } from 'formik'
import React from 'react'
import { useEffect } from 'react'
import { useState } from 'react'
import { Button ,Form} from 'react-bootstrap'
import { useNavigate, useParams } from 'react-router-dom'
import { toast } from 'react-toastify'
import OfferService from '../../api/services/OfferService'
function UpdateOffer() {

  const { offerId } = useParams()
  const offerService = new OfferService()
  const [offer, setOffer] = useState({})
  const navigate = useNavigate() 
  const token = localStorage.getItem("token")

  const getData = async () => {
    try {
      let result = await offerService.getOfferById(offerId)
      setOffer(result.data.data)
    } catch (error) {
      console.log(error)
    }
  }
  const formik = useFormik({
    initialValues: {
      offerId : offerId,
      productId: 0,
      userId: 0,
      offeredPrice: 0,
    },
    onSubmit: async (values) => {
      try {
        values.productId = offer.productId
        values.userId = offer.userId
        values.isAccepted =offer.isAccepted
        await offerService.update(values, token)
        toast.success("Successfully Updated !")
        navigate("/myoffers")
      } catch (error) {
        console.log(values)
        console.log(error)
        toast.error("Error")
      }
    }
  })

  useEffect(() => {
    getData()
  }, [offerId])

  return (
    <div>
      <h4>Update Offer</h4>
      <form onSubmit={formik.handleSubmit}>
        <Form.Control
          size='lg'
          placeholder='Offered Price'
          autoComplete='off'
          value={formik.values.offeredPrice}
          name="offeredPrice"
          onChange={formik.handleChange}
          onBlur={formik.handleBlur}
          type='number'
        />
        {formik.errors.name && formik.touched.name && formik.errors.name}
        <br />
        <Button type='submit' size='lg'>Update</Button>
      </form>
    </div>
  )
}

export default UpdateOffer