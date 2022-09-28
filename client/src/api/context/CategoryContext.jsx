import { useCallback } from "react";
import { createContext, useEffect, useState } from "react";
import CategoryService from "../services/CategoryService";

const CategoryContext = createContext()

export const CategoryProvider=({children})=>{
    
    const [categories,setCategories]=useState([])
    const categoryService = new CategoryService()
    
    const getData =async()=>{
        try {
            let result = await categoryService.getCategories()
            setCategories(result.data.data)    
        } catch (error) {
            console.log(error)
        }
    }

    useEffect(()=>{
        getData()
    },[])

    const values ={
        categories,
        setCategories,
        getData
    }

    return <CategoryContext.Provider value={values}>{children}</CategoryContext.Provider>
}

export default CategoryContext