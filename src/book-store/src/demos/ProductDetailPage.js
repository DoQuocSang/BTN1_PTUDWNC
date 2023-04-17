import React from "react";
import AnimationRevealPage from "helpers/AnimationRevealPage.js";
import Hero from "components/hero/BackgroundAsImageWithCenteredContent.js";
import Features from "components/features/TwoColSingleFeatureWithStats2";
import Blog from "components/blogs/ThreeColSimpleWithImage.js";
import Testimonial from "components/testimonials/SimplePrimaryBackground";
import ContactUsForm from "components/forms/SimpleContactUs.js";
import Footer from "components/footers/SimpleFiveColumn.js";
import Header from "components/headers/light.js"
import SliderCard from "components/cards/ThreeColSlider.js";

export default () => (
  <AnimationRevealPage>
    <Features />
    <Testimonial />
    <SliderCard HeadingText="Sản phẩm liên quan"/>
  </AnimationRevealPage>
);
