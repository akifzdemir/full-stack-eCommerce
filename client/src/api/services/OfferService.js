import axios from "axios";
import { apiUrl } from "../ApiUrl";

export default class OfferService{
    getOfferById(offerId){
        return axios.get(apiUrl+"/offers/getbyid?id="+offerId)
    }
    getOfferDetailsByUser(userId){
        return axios.get(apiUrl+"/Offers/getdetailsbyuser?userId="+userId)
    }
    getOfferDetailsByProduct(productId){
        return axios.get(apiUrl+"/Offers/getdetailsbyproduct?productId="+productId)
    }
    add(values,token){
        return axios.post(apiUrl+"/offers/add",values,{
            headers:{
                'Authorization':"Bearer "+token
            } 
        })
    }
    delete(values,token){
        return axios.post(apiUrl+"/offers/delete",values,{
            headers:{
                'Authorization':"Bearer "+token
            }
        })
    }
    update(values,token){
        return axios.put(apiUrl+"/offers/update",values,{
            headers:{
                'Authorization':"Bearer "+token
            }
        })
    }
    updateIsAccepted(offerId,value){
        return axios.put(apiUrl+`/offers/updateisaccepted?offerId=${offerId}&isAccepted=${value}`)
    }
}