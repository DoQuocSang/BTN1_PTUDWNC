import React from "react"
import "style.css"
import "tailwindcss/lib/css/preflight.css"
import AnimationRevealPage from "helpers/AnimationRevealPage"
import Hero from "components/hero/FullWidthWithImage"
import RestaurantLandingPage from "demos/RestaurantLandingPage"
import HomePage from "demos/HomePage"
import "fontawesome"
import AllProductPage from "demos/AllProductPage"
import AboutUs from "pages/AboutUs"
import Login from "pages/Login"
import Signup from "pages/Signup"
import ProductDetailPage from "demos/ProductDetailPage"

function App() {
  return (
    <AnimationRevealPage>
      {/* <HomePage /> */}
      {/* <AllProductPage /> */}
      {/* <Login /> */}
      {/* <Signup /> */}
      <ProductDetailPage />
    </AnimationRevealPage>
  )
}

export default App