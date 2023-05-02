import React from "react"
import "style.css"
import tw from "twin.macro";
import "tailwindcss/lib/css/preflight.css"
import AnimationRevealPage from "helpers/AnimationRevealPage"
import HomePage from "pages/user/HomePage"
import AllProductPage from "pages/user/AllProductPage"
import AboutUs from "pages/user/AboutUs"
import UserLogin from "pages/user/Login"
import UserSignup from "pages/user/Signup"
import ProductDetailPage from "pages/user/ProductDetailPage"
import BlogIndex from "pages/user/BlogIndex"
import BlogDetail from "pages/user/BlogDetail"
import UserLayout from "components/user/layout/Layout"
import AdminLayout from "components/admin/layout/Layout"
import Dashboard from "pages/admin/dashboard/Dashboard"

import AllProduct from "pages/admin/product/AllProduct"
import AddProduct from "pages/admin/product/AddProduct"

import AllCategory from "pages/admin/category/AllCategory"
import AddCategory from "pages/admin/category/AddCategory"

import AllAuthor from "pages/admin/author/AllAuthor"
import AddAuthor from "pages/admin/author/AddAuthor"

import AllTag from "pages/admin/tag/AllTag"
import AddTag from "pages/admin/tag/AddTag"

import AllBlog from "pages/admin/blog/AllBlog"
import AddBlog from "pages/admin/blog/AddBlog"

import AllUser from "pages/admin/user/AllUser"
import AddUser from "pages/admin/user/AddUser"

import AdminLogin from "pages/admin/login/Login"


import { Route, Routes } from "react-router-dom"
import Cart from "pages/user/Cart";

function App() {
  return (
    <AnimationRevealPage>
      <Routes>
        <Route path="/" element={<UserLayout />}>
          <Route path="/" element={<HomePage />} />
          <Route path="/login" element={<UserLogin />} />
          <Route path="/signup" element={<UserSignup />} />
          <Route path="/all-product" element={<AllProductPage />} />
          <Route path="/all-product/:type/:slug" element={<AllProductPage />} />
          <Route path="/product-detail/:slug" element={<ProductDetailPage />} />
          <Route path="/about-us" element={<AboutUs />} />
          <Route path="/blog" element={<BlogIndex />} />
          <Route path="/blog-detail/:slug" element={<BlogDetail />} />
          <Route path="/cart" element={<Cart />} />
        </Route>

        <Route path="/admin" element={<AdminLogin />} />

        <Route path="/admin/dashboard" element={<AdminLayout />}>
          <Route path="/admin/dashboard" element={<Dashboard />} />
          <Route path="/admin/dashboard/all-product" element={<AllProduct />} />
          <Route path="/admin/dashboard/add-product" element={<AddProduct />} />
          <Route path="/admin/dashboard/all-category" element={<AllCategory />} />
          <Route path="/admin/dashboard/add-category" element={<AddCategory />} />
          <Route path="/admin/dashboard/all-author" element={<AllAuthor />} />
          <Route path="/admin/dashboard/add-author" element={<AddAuthor />} />
          <Route path="/admin/dashboard/all-tag" element={<AllTag />} />
          <Route path="/admin/dashboard/add-tag" element={<AddTag />} />
          <Route path="/admin/dashboard/all-blog" element={<AllBlog />} />
          <Route path="/admin/dashboard/add-blog" element={<AddBlog />} />
          <Route path="/admin/dashboard/all-user" element={<AllUser />} />
          <Route path="/admin/dashboard/add-user" element={<AddUser />} />
        </Route>

      </Routes>
    </AnimationRevealPage>
  )
}

export default App