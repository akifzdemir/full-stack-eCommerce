import axios from "axios";
import {apiUrl} from "../ApiUrl";


export default class ProductService{
    getProducts(){
        return axios.get(apiUrl+"/products/getall")
    }
    getProductById(id){
        return axios.get(apiUrl+"/products/getbyid?id="+id)
    }
    getProductDetails(){
        return axios.get(apiUrl+"/products/getallproductdetails")
    }
    getProductDetailById(productId){
        return axios.get(apiUrl+"/Products/getproductdetailById?productId="+productId)
    }
    getProductDetailsByCategory(categoryId){
        return axios.get(apiUrl+"/products/getproductdetailsbycategory?categoryId="+categoryId)
    }
    getUserProducts(userId){
        return axios.get(apiUrl+"/products/getproductsbyuserid?userId="+userId)
    }
    addProduct(values,token){
        return axios.post(apiUrl+"/products/add",values,{
            headers:{
                'Authorization':"Bearer "+token
            }
        })
    }
    deleteProduct(values,token){
        return axios.post(apiUrl+"/products/delete",values,{
            headers:{
                'Authorization':"Bearer "+token
            }
        })
    }
    updateIsSold(produtId,value,token){
        return axios.put(apiUrl+`/products/updateissold?productId=${produtId}&isSold=${value}`,value,{
            headers:{
                'Authorization':"Bearer "+token
            }
        })
    }
}