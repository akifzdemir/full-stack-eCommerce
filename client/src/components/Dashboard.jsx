import { Container, Row, Col} from 'react-bootstrap'
import NavBar from './NavBar'
import ProductList from '../pages/product/ProductList'
import { Routes ,Route} from 'react-router-dom'
import CategoryList from './CategoryList'
import Categories from '../pages/category/Categories'
import { ToastContainer } from 'react-toastify'
import AddCategory from '../pages/category/AddCategory'
import AddProduct from '../pages/product/AddProduct'
import Register from '../pages/auth/Register'
import Login from '../pages/auth/Login'
import { useContext } from 'react'
import AuthContext from '../api/context/AuthContext'
import UserProducts from '../pages/user/UserProducts'
import UserOffers from '../pages/user/UserOffers'
import OfferToProduct from '../pages/offer/OfferToProduct'
import ProductOffers from '../pages/offer/ProductOffers'
import Protected from '../pages/Protected'
import UpdateCategory from '../pages/category/UpdateCategory'
import ProductDetail from '../pages/product/ProductDetail'
import UpdateOffer from '../pages/offer/UpdateOffer'
import OfferWithPercent from '../pages/offer/OfferWithPercent'

function Dashboard() {

    const {auth} = useContext(AuthContext)

    return (
        <>
            <NavBar />
            <ToastContainer/>
            <Container>
                <br />
                <Row >
                    <Col md={3}>      
                            <CategoryList />    
                    </Col>
                    <Col md={9}>
                       <Routes>
                        <Route path='/' element={<ProductList/>} />
                        <Route path='/product/:productId' element={<ProductDetail/>}/>
                        <Route path='/:categoryId' element={<ProductList/>}/>
                        <Route path='/categories' element={auth ? <Categories/> : <Protected/>}/>
                        <Route path='/addcategory' element={auth ? <AddCategory/> : <Protected/>}/>
                        <Route path='/addproduct' element={auth ? <AddProduct/> : <Protected/> } />
                        <Route path='/register' element={<Register/>}/>                         
                        <Route path='/login' element={<Login/>}/>
                        <Route path='/myproducts' element={auth ? <UserProducts/> : <Protected/>}/>
                        <Route path='/myoffers' element={auth ? <UserOffers/>: <Protected/>}/>
                        <Route path='/myoffers/update/:offerId' element={auth ? <UpdateOffer/>: <Protected/>}/>
                        <Route path='/offer/:productId' element={auth ? <OfferToProduct/> : <Protected/>}/>
                        <Route path='/offerWithPercent/:productId' element={auth ? <OfferWithPercent/> : <Protected/>}/>
                        <Route path='/myproducts/offers/:productId' element={auth ? <ProductOffers/> : <Protected/>}/>
                        <Route path='/updateCategory/:categoryId' element={auth ? <UpdateCategory/> : <Protected/>}/>
                       </Routes>
                    </Col>
                </Row>
            </Container>
            <br />
        </>
    )
}

export default Dashboard