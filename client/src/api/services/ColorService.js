import axios from 'axios'
import { apiUrl } from '../ApiUrl'

export default class ColorService{
    getColors(){
        return axios.get(apiUrl+"/colors/getall")
    }
}