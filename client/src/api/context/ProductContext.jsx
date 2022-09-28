import { createContext, useState } from "react";
import { toast } from "react-toastify";
import ProductService from "../services/ProductService";


const ProductContext = createContext();

export const ProductProvider=({children})=>{

    const productService = new ProductService()
    const [products,setProducts] = useState([]);
    const [buyButton,setBuyButton]=useState(false)
    
    const handleBuy = async (productId,price) => {
        const isSold = true;
        setBuyButton(true)
        try {
            const token =localStorage.getItem("token")
            if (token) {
                await productService.updateIsSold(productId, isSold, token)
                setBuyButton(false)
                toast.success("The product was successfully bought at this price : "+price+"$")
            } else {
                toast.error("You need to login for this operation")
            }
        } catch (error) {
            console.log(error)
        }
        
    }

    const getData = async()=>{
        try {
            let result = await productService.getProductDetails()
            setProducts(result.data.data)
        } catch (error) {
            console.log(error)
        }
    }
   
    const values = {
        products,
        setProducts,
        getData,
        handleBuy,
        buyButton
    }
    return <ProductContext.Provider value={values}>{children}</ProductContext.Provider>
}

export default ProductContext