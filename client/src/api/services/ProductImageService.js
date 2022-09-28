import axios from "axios";
import { apiUrl } from "../ApiUrl";

export default class ProductImageService{
    addImage(values,config){
        return axios.post(apiUrl+"/productImages/add",values,config)
    }
}
