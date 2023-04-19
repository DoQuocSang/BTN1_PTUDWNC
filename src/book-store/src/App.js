import React from "react"
import "style.css"
import tw from "twin.macro";
import "tailwindcss/lib/css/preflight.css"
import AnimationRevealPage from "helpers/AnimationRevealPage"
import Hero from "components/hero/FullWidthWithImage"
import RestaurantLandingPage from "demos/RestaurantLandingPage"
import HomePage from "demos/HomePage"
import AllProductPage from "demos/AllProductPage"
import AboutUs from "pages/AboutUs"
import UserLogin from "pages/Login"
import UserSignup from "pages/Signup"
import ProductDetailPage from "demos/ProductDetailPage"
import BlogIndex from "pages/BlogIndex"
import UserLayout from "components/layout/Layout"
import AdminLayout from "components/admin/layout/Layout"
import Dashboard from "components/admin/dashboard/Dashboard"
import AllProduct from "components/admin/product/AllProduct"
import AddProduct from "components/admin/product/AddProduct"
import AdminLogin from "components/admin/login/Login"


import { Route, Routes } from "react-router-dom"

function App() {
  return (
    <AnimationRevealPage>
      <Routes>
        <Route path="/" element={<UserLayout />}>
          <Route path="/" element={<HomePage />} />
          <Route path="/login" element={<UserLogin />} />
          <Route path="/signup" element={<UserSignup />} />
          <Route path="/all-product" element={<AllProductPage />} />
          <Route path="/product-detail" element={<ProductDetailPage />} />
          <Route path="/about-us" element={<AboutUs />} />
          <Route path="/blog" element={<BlogIndex />} />
        </Route>

        <Route path="/admin" element={<AdminLogin />} />

        <Route path="/admin/dashboard" element={<AdminLayout />}>
          <Route path="/admin/dashboard" element={<Dashboard />} />
          <Route path="/admin/dashboard/all-product" element={<AllProduct />} />
          <Route path="/admin/dashboard/add-product" element={<AddProduct />} />
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