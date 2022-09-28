import * as yup from 'yup'

const offerSchema= yup.object().shape({
   offeredPrice:yup.number().positive().required()
})

export default offerSchema