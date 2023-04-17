import React from "react";
import { Outlet } from "react-router-dom";
import Header from "components/headers/light.js";
import Footer from "components/footers/SimpleFiveColumn.js";

export default () => {

  return (
    <>
      <Header />
      <Outlet />
      <Footer />
    </>
  );
};
