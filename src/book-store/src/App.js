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
import AddOrUpdateProduct from "pages/admin/product/AddOrUpdateProduct"

import AllCategory from "pages/admin/category/AllCategory"
import AddOrUpdateCategory from "pages/admin/category/AddOrUpdateCategory"

import AllAuthor from "pages/admin/author/AllAuthor"
import AddOrUpdateAuthor from "pages/admin/author/AddOrUpdateAuthor"

import AllTag from "pages/admin/tag/AllTag"
import AddOrUpdateTag from "pages/admin/tag/AddOrUpdateTag"

import AllBlog from "pages/admin/blog/AllBlog"
import AddOrUpdateBlog from "pages/admin/blog/AddOrUpdateBlog"

import AllUser from "pages/admin/user/AllUser"
import AddOrUpdateUser from "pages/admin/user/AddOrUpdateUser"

import AdminLogin from "pages/admin/login/Login"

import NotFound404 from "./pages/user/NotFound404";


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
          <Route path="/blog/:type/:slug" element={<BlogIndex />} />
          <Route path="/blog-detail/:slug" element={<BlogDetail />} />
          <Route path="/cart" element={<Cart />} />
          <Route path="/not-found-404" element={<NotFound404 />} />
        </Route>

        <Route path="/admin" element={<AdminLogin />} />

        <Route path="/admin/dashboard" element={<AdminLayout />}>
          <Route path="/admin/dashboard" element={<Dashboard />} />
          <Route path="/admin/dashboard/all-product" element={<AllProduct />} />
          <Route path="/admin/dashboard/add-product" element={<AddOrUpdateProduct type="add" />} />
          <Route path="/admin/dashboard/update-product/:id" element={<AddOrUpdateProduct type="update" />} />

          <Route path="/admin/dashboard/all-category" element={<AllCategory />} />
          <Route path="/admin/dashboard/add-category" element={<AddOrUpdateCategory type="add" />} />
          <Route path="/admin/dashboard/update-category/:id" element={<AddOrUpdateCategory type="update" />} />

          <Route path="/admin/dashboard/all-author" element={<AllAuthor />} />
          <Route path="/admin/dashboard/add-author" element={<AddOrUpdateAuthor type="add"/>} />
          <Route path="/admin/dashboard/update-author/:id" element={<AddOrUpdateAuthor type="update" />} />

          <Route path="/admin/dashboard/all-tag" element={<AllTag />} />
          <Route path="/admin/dashboard/add-tag" element={<AddOrUpdateTag type="add"/>} />
          <Route path="/admin/dashboard/update-tag/:id" element={<AddOrUpdateTag type="update" />} />

          <Route path="/admin/dashboard/all-blog" element={<AllBlog />} />
          <Route path="/admin/dashboard/add-blog" element={<AddOrUpdateBlog type="add" />} />
          <Route path="/admin/dashboard/update-blog/:id" element={<AddOrUpdateBlog type="update" />} />

          <Route path="/admin/dashboard/all-user" element={<AllUser />} />
          <Route path="/admin/dashboard/add-user" element={<AddOrUpdateUser type="add" />} />
          <Route path="/admin/dashboard/update-user/:id" element={<AddOrUpdateUser type="update" />} />
        </Route>

        {/* <Route path="*" element={<NotFound404 />} /> */}

      </Routes>
    </AnimationRevealPage>
  )
}

export default App