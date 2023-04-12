import React from "react"
import "style.css"
import "tailwindcss/lib/css/preflight.css"
import AnimationRevealPage from "helpers/AnimationRevealPage"
import Hero from "components/hero/FullWidthWithImage"
import RestaurantLandingPage from "demos/RestaurantLandingPage"
import HomePage from "demos/HomePage"
import "fontawesome"
import AllProductPage from "demos/AllProductPage"

function App() {
  return (
    <AnimationRevealPage>
      <HomePage />
      {/* <AllProductPage /> */}
    </AnimationRevealPage>
  )
}

export default App