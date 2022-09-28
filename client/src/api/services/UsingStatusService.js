import axios from "axios";
import { apiUrl } from "../ApiUrl";

export default class UsingStatusService{
    getUsingStatus(){
       return axios.get(apiUrl+"/usingstatuses/getall")
    }
}