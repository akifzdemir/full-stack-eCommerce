import * as yup from 'yup'

const productSchema = yup.object().shape({
    productName:yup.string().required().max(100),
    description:yup.string().required().max(500),
    categoryId:yup.number().required("Category is required"),
    usingStatusId:yup.number().required("Using Status is required"),
    price:yup.number().required(),
    isOfferable:yup.bool().required().default(false)
})

export default productSchema