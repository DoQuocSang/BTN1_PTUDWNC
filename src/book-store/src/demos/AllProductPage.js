import React from "react";
import tw from "twin.macro";
import AnimationRevealPage from "helpers/AnimationRevealPage.js";
import Header from "components/headers/light.js"
import TabGrid from "components/cards/TabBookCardGrid.js";
import SubscribeNewsLetterForm from "components/forms/TwoColContactUsWithIllustration";
import Footer from "components/footers/FiveColumnWithInputForm.js";



export default ({ roundedHeaderButton }) => {
    return (
        <AnimationRevealPage>
            <Header roundedHeaderButton={roundedHeaderButton} />
            <TabGrid
                heading={
                    <>
                        Danh sách sản phẩm 
                    </>
                }
            />
            <SubscribeNewsLetterForm />
            <Footer />
        </AnimationRevealPage>
    );
}

