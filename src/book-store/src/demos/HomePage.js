import React from "react";
import AnimationRevealPage from "helpers/AnimationRevealPage.js";
import Hero from "components/hero/TwoColumnWithInput";
import Features from "components/features/DashedBorderSixFeatures";
import MainFeature from "components/features/VerticalWithAlternateImageAndText";
import SliderCard from "components/cards/ThreeColSlider.js";
import TrendingCard from "components/cards/TwoTrendingPreviewCardsWithImage.js";
import Blog from "components/blogs/PopularAndRecentBlogPosts.js";
import Testimonial from "components/testimonials/TwoColumnWithImageAndProfilePictureReview.js";
import FAQ from "components/faqs/SimpleWithSideImage.js";
import SubscribeNewsLetterForm from "components/forms/TwoColContactUsWithIllustration";
import Footer from "components/footers/SimpleFiveColumn";
import EventLandingPage from "./EventLandingPage";

export default () => (
  <AnimationRevealPage>
    <Hero />
    <Features />
    <MainFeature />
    <SliderCard />
    <Blog />
    <SubscribeNewsLetterForm />
  </AnimationRevealPage>
);
