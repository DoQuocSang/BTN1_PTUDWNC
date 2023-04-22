import React from "react";
import AnimationRevealPage from "helpers/AnimationRevealPage.js";
import Features from "components/user/features/TwoColSingleFeatureWithStats2";
import Testimonial from "components/user/testimonials/SimplePrimaryBackground";
import SliderCard from "components/user/cards/ThreeColSlider.js";

export default () => (
  <AnimationRevealPage>
    <Features />
    <Testimonial />
    <SliderCard HeadingText="Sản phẩm liên quan"/>
  </AnimationRevealPage>
);
