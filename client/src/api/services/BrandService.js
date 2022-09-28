import axios from "axios";
import { apiUrl } from "../ApiUrl";

export default class BrandService{
    getBrands(){
       return axios.get(apiUrl+"/brands/getall")
    }
}