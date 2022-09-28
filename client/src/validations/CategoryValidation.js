import * as yup from 'yup'

const categorySchema = yup.object().shape({
    name:yup.string().required()
})

export default categorySchema