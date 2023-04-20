import React from "react";
import { Outlet } from "react-router-dom";
import Header from "components/user/headers/light.js";
import Footer from "components/user/footers/SimpleFiveColumn.js";

export default () => {

  return (
    <>
      <Header />
      <Outlet />
      <Footer />
    </>
  );
};
