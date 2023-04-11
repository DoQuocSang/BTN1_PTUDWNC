import React from "react"
import "style.css"
import "tailwindcss/lib/css/preflight.css"
import AnimationRevealPage from "helpers/AnimationRevealPage"
import Hero from "components/hero/FullWidthWithImage"
import RestaurantLandingPage from "demos/RestaurantLandingPage"
import HotelTravelLandingPage from "demos/HotelTravelLandingPage"

function App() {
  return (
    <AnimationRevealPage>
      <HotelTravelLandingPage/>
    </AnimationRevealPage>
  )
}

export default App