import axios from "axios";
import { apiUrl } from "../ApiUrl";

export default class CategoryService{
    getCategories(){
        return axios.get(apiUrl+"/categories/getall")
    }
    getCategoryById(categoryId){
        return axios.get(apiUrl+"/Categories/getbyid?id="+categoryId)
    }
    add(values,token){
        return axios.post(apiUrl+"/categories/add",values,{
            headers:{
                'Authorization':"Bearer "+token
            }
        })
    }
    update(values,token){
        return axios.put(apiUrl+"/categories/update",values,{
            headers:{
                'Authorization':"Bearer "+token
            }
        })
    }

    delete(values,token){
        return axios.post(apiUrl+"/categories/delete",values,{
            headers:{
                'Authorization':"Bearer "+token
            }
        })
    }
}