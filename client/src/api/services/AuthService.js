import axios from "axios";
import { apiUrl } from "../ApiUrl";

export default class AuthService{
    login(values){
      return  axios.post(apiUrl+"/auth/login",values)
    }
    register(values){
     return  axios.post(apiUrl+"/auth/register",values)
    }
    sendWelcomeEmail(email){
      return  axios.post(apiUrl+"/Auth/sendwelcomeemail?email="+email)
    }
}