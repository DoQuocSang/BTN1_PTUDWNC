import React from "react"
import "style.css"
import "tailwindcss/lib/css/preflight.css"
import AnimationRevealPage from "helpers/AnimationRevealPage"
import Hero from "components/hero/FullWidthWithImage"
import RestaurantLandingPage from "demos/RestaurantLandingPage"
import HomePage from "demos/HomePage"
import Dashboard from "demos/Dashboard"
import "fontawesome"
import AllProductPage from "demos/AllProductPage"
import AboutUs from "pages/AboutUs"
import Login from "pages/Login"
import Signup from "pages/Signup"
import ProductDetailPage from "demos/ProductDetailPage"
import BlogIndex from "pages/BlogIndex"
import UserLayout from "components/layout/Layout"
import AdminLayout from "components/admin/layout/Layout"


import { Route, Routes } from "react-router-dom"

function App() {
  return (
    <AnimationRevealPage>
      <Routes>
        <Route path="/" element={<UserLayout />}>
          <Route path="/" element={<HomePage />} />
          <Route path="/login" element={<Login />} />
          <Route path="/signup" element={<Signup />} />
          <Route path="/all-product" element={<AllProductPage />} />
          <Route path="/product-detail" element={<ProductDetailPage />} />
          <Route path="/about-us" element={<AboutUs />} />
          <Route path="/blog" element={<BlogIndex />} />
        </Route>

        <Route path="/admin" element={<AdminLayout />}>
          {/* <Route path="/" element={<HomePage />} /> */}
        </Route>

      </Routes>
      {/* <HomePage /> */}
      {/* <AllProductPage /> */}
      {/* <Login /> */}
      {/* <Signup /> */}
      {/* <ProductDetailPage /> */}
      {/* <AboutUs /> */}
      {/* <BlogIndex /> */}
    </AnimationRevealPage>
  )
}

export default App