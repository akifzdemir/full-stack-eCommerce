import { CategoryProvider } from './api/context/CategoryContext';
import { ColorProvider } from './api/context/ColorContext';
import { ProductProvider } from './api/context/ProductContext';
import './App.css';
import { BrandProvider } from './api/context/BrandContext';
import Dashboard from './components/Dashboard';
import {UsingStatusProvider} from './api/context/UsingStatusContext'
import { AuthProvider } from './api/context/AuthContext';

function App() {
  return (
    <div>
       <AuthProvider>
      <ColorProvider>
      <CategoryProvider>
        <ProductProvider>
          <BrandProvider>
         <UsingStatusProvider>
          <Dashboard />     
         </UsingStatusProvider>    
          </BrandProvider>
        </ProductProvider>
      </CategoryProvider>
      </ColorProvider>
      </AuthProvider>
    </div>
  );
}

export default App;
