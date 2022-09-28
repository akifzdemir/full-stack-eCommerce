import * as yup from 'yup'

const registerSchema= yup.object().shape({
    email:yup.string().email().required(),
    password:yup.string().required().min(8).max(25),
    firstName:yup.string().required(),
    lastName:yup.string().required()
})

export default registerSchema