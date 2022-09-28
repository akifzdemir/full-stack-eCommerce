import { createContext, useEffect, useState } from "react";
import BrandService from "../services/BrandService";

const BrandContext = createContext()

export const BrandProvider=({children})=>{

    const brandService = new BrandService()
    const [brands,setBrands]=useState([])

    const getData =async()=>{
        try {
            let result = await brandService.getBrands()
            setBrands(result.data.data)
        } catch (error) {
            console.log(error)
        }
    }

    useEffect(()=>{
        getData()
    },[])

    const values ={
        brands,
        setBrands
    }

    return <BrandContext.Provider value={values}>{children}</BrandContext.Provider>
}
export default BrandContext