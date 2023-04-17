import React from "react";
import { Outlet } from "react-router-dom";

export default () => {

  return (
    <>
        <h1 className="text-danger" >Admin</h1>
      <Outlet />
    </>
  );
};
