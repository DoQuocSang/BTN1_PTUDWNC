import React from "react";
import { motion } from "framer-motion";
import tw from "twin.macro";
import styled from "styled-components";
import { css } from "styled-components/macro"; //eslint-disable-line

import useAnimatedNavToggler from "../../helpers/useAnimatedNavToggler.js";

import logo from "../../images/logo.png";
import { ReactComponent as MenuIcon } from "feather-icons/dist/icons/menu.svg";
import { ReactComponent as CloseIcon } from "feather-icons/dist/icons/x.svg";
import { faShoppingCart } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faFileLines } from "@fortawesome/free-solid-svg-icons";
import { faPeopleRoof } from "@fortawesome/free-solid-svg-icons";
import { faListUl } from "@fortawesome/free-solid-svg-icons";
import { faMagnifyingGlass } from "@fortawesome/free-solid-svg-icons";
import { faBoltLightning } from "@fortawesome/free-solid-svg-icons";
import { faBook } from "@fortawesome/free-solid-svg-icons";
import { faFire } from "@fortawesome/free-solid-svg-icons";
import { faUserPen } from "@fortawesome/free-solid-svg-icons";
import { faBookmark } from "@fortawesome/free-solid-svg-icons";
import catFind from "images/cat-find.png"

const Header = tw.header`
  flex justify-between items-center
  max-w-screen-xl mx-auto
`;

export const NavLinks = tw.div`inline-block`;

/* hocus: stands for "on hover or focus"
 * hocus:bg-primary-700 will apply the bg-primary-700 class on hover or focus
 */
export const NavLink = tw.a`
  text-lg my-2 lg:text-sm lg:mx-6 lg:my-0
  font-semibold tracking-wide transition duration-300
  pb-1 border-b-2 border-transparent hover:border-primary-500 hocus:text-primary-500
`;

export const PrimaryLink = tw(NavLink)`
  lg:mx-0
  px-8 py-3 rounded bg-primary-500 text-gray-100
  hocus:bg-primary-700 hocus:text-gray-200 focus:shadow-outline
  border-b-0
`;

export const LogoLink = styled(NavLink)`
  ${tw`flex items-center font-black border-b-0 text-2xl! ml-0!`};

  img {
    ${tw`w-10 mr-3`}
  }
`;

export const MobileNavLinksContainer = tw.nav`flex flex-1 items-center justify-between`;
export const NavToggle = tw.button`
  lg:hidden z-20 focus:outline-none hocus:text-primary-500 transition duration-300
`;
export const MobileNavLinks = motion(styled.div`
  ${tw`lg:hidden z-10 fixed top-0 inset-x-0 mx-4 my-6 p-8 border text-center rounded-lg text-gray-900 bg-white`}
  ${NavLinks} {
    ${tw`flex flex-col items-center`}
  }
`);

export const DesktopNavLinks = tw.nav`
  hidden lg:flex flex-1 justify-between items-center
`;

export const MenuOnHover = tw.div`invisible py-5 absolute z-50 rounded-md flex bg-gray-100 py-1 px-4 text-gray-800 shadow-xl group-hover:visible`;
export const MenuItem = tw.a`px-5 py-3 hover:text-primary-500 transition duration-300 text-gray-600`;

export const MenuContainer = styled.div(({ flexCol }) => [
  tw`grid grid-cols-4 grow-0 mb-5`,
  flexCol && tw`flex flex-col`,
])

export const MenuTitle = tw.h2`px-5 font-semibold text-base text-red-500`;
export const MenuSection = styled.div(({ hasBorder }) => [
  tw``,
  hasBorder && tw`border-r-2 border-gray-300`,
])

const Actions = styled.div`
  ${tw`relative max-w-md text-center mx-auto lg:mx-0`}
  input {
    ${tw`sm:pr-48 pl-8 py-4 sm:py-4 rounded-full border-2 w-full font-medium focus:outline-none transition duration-300  focus:border-primary-500 hover:border-gray-500`}
  }
  button {
    ${tw`w-full sm:absolute right-0 top-0 bottom-0 bg-primary-500 text-gray-100 font-bold mr-2 my-4 sm:my-2 rounded-full py-4 flex items-center justify-center sm:w-40 sm:leading-none focus:outline-none hover:bg-primary-900 transition duration-300`}
  }
`;

export const ImageFinding = tw.img`text-center w-1/2 mx-auto`;



export default ({ roundedHeaderButton = false, logoLink, links, className, collapseBreakpointClass = "lg" }) => {
  /*
   * This header component accepts an optionals "links" prop that specifies the links to render in the navbar.
   * This links props should be an array of "NavLinks" components which is exported from this file.
   * Each "NavLinks" component can contain any amount of "NavLink" component, also exported from this file.
   * This allows this Header to be multi column.
   * So If you pass only a single item in the array with only one NavLinks component as root, you will get 2 column header.
   * Left part will be LogoLink, and the right part will be the the NavLinks component you
   * supplied.
   * Similarly if you pass 2 items in the links array, then you will get 3 columns, the left will be "LogoLink", the center will be the first "NavLinks" component in the array and the right will be the second "NavLinks" component in the links array.
   * You can also choose to directly modify the links here by not passing any links from the parent component and
   * changing the defaultLinks variable below below.
   * If you manipulate links here, all the styling on the links is already done for you. If you pass links yourself though, you are responsible for styling the links or use the helper styled components that are defined here (NavLink)
   */
  const defaultLinks = [
    <NavLinks key={1}>
      <NavLink href="/#" className="group relative">
        <FontAwesomeIcon icon={faListUl} css={tw`mr-2 text-base`} />
        Danh mục
        <MenuOnHover>
          <MenuSection hasBorder>
            <MenuTitle>
              <FontAwesomeIcon icon={faBoltLightning} css={tw`mr-2 text-base`} />
              Truy cập nhanh
            </MenuTitle>
            <MenuContainer flexCol>
              <MenuItem href="#">
                Sách mới
              </MenuItem>
              <MenuItem href="#">
                Sách bán chạy
              </MenuItem>
              <MenuItem href="#">
                Sách nổi bật
              </MenuItem>
              <MenuItem href="#">
                Đang giảm giá
              </MenuItem>
            </MenuContainer>
          </MenuSection>

          <MenuSection flexCol>
            <MenuSection>
              <MenuTitle>
                <FontAwesomeIcon icon={faUserPen} css={tw`mr-2 text-base`} />
                Tác giả
              </MenuTitle>
              <MenuContainer >
                <MenuItem href="#">
                  Sách thiếu nhi
                </MenuItem>
                <MenuItem href="#">
                  Sách văn học
                </MenuItem>
                <MenuItem href="#">
                  Sách nổi bật
                </MenuItem>
                <MenuItem href="#">
                  Đang giảm giá
                </MenuItem>
                <MenuItem href="#">
                  Sách bán chạy
                </MenuItem>
                <MenuItem href="#">
                  Sách thiếu nhi
                </MenuItem>
                <MenuItem href="#">
                  Sách văn học
                </MenuItem>
                <MenuItem href="#">
                  Sách nổi bật
                </MenuItem>
                <MenuItem href="#">
                  Đang giảm giá
                </MenuItem>
                <MenuItem href="#">
                  Sách bán chạy
                </MenuItem>
              </MenuContainer>
            </MenuSection>
            <MenuSection>
              <MenuTitle>
                <FontAwesomeIcon icon={faBook} css={tw`mr-2 text-base`} />
                Thể loại
              </MenuTitle>
              <MenuContainer >
                <MenuItem href="#">
                  Sách thiếu nhi
                </MenuItem>
                <MenuItem href="#">
                  Sách văn học
                </MenuItem>
                <MenuItem href="#">
                  Sách nổi bật
                </MenuItem>
                <MenuItem href="#">
                  Đang giảm giá
                </MenuItem>
                <MenuItem href="#">
                  Sách bán chạy
                </MenuItem>
                <MenuItem href="#">
                  Sách thiếu nhi
                </MenuItem>
                <MenuItem href="#">
                  Sách văn học
                </MenuItem>
                <MenuItem href="#">
                  Sách nổi bật
                </MenuItem>
                <MenuItem href="#">
                  Đang giảm giá
                </MenuItem>
                <MenuItem href="#">
                  Sách bán chạy
                </MenuItem>
              </MenuContainer>
            </MenuSection>
          </MenuSection>

        </MenuOnHover>
      </NavLink>



      <NavLink href="/#" className="group relative">
        <FontAwesomeIcon icon={faMagnifyingGlass} css={tw`mr-2 text-base`} />
        Tìm kiếm
        <MenuOnHover>
          <MenuSection flexCol>
              <ImageFinding src={catFind} />
              <Actions>
                <input type="text" placeholder="Nhập tên sách cần tìm..." />
                <button>Tìm kiếm</button>
              </Actions>
          </MenuSection>
        </MenuOnHover>
      </NavLink>

      <NavLink href="/#">
        <FontAwesomeIcon icon={faPeopleRoof} css={tw`mr-2 text-base`} />
        Giới thiệu
      </NavLink>

      <NavLink href="/#">
        <FontAwesomeIcon icon={faFileLines} css={tw`mr-2 text-base`} />
        Bài viết
      </NavLink>

      <NavLink href="/#">
        <FontAwesomeIcon icon={faShoppingCart} css={tw`mr-2 text-base`} />
        Giỏ hàng
      </NavLink>

      <NavLink href="/#" tw="lg:ml-12!">
        Đăng nhập
      </NavLink>
      <PrimaryLink css={roundedHeaderButton && tw`rounded-full`} href="/#">Đăng ký</PrimaryLink>
    </NavLinks>
  ];

  const { showNavLinks, animation, toggleNavbar } = useAnimatedNavToggler();
  const collapseBreakpointCss = collapseBreakPointCssMap[collapseBreakpointClass];

  const defaultLogoLink = (
    <LogoLink href="/">
      <img src={logo} alt="logo" />
      Fahasa
    </LogoLink>
  );

  logoLink = logoLink || defaultLogoLink;
  links = links || defaultLinks;

  return (
    <Header className={className || "header-light"}>
      <DesktopNavLinks css={collapseBreakpointCss.desktopNavLinks}>
        {logoLink}
        {links}
      </DesktopNavLinks>

      <MobileNavLinksContainer css={collapseBreakpointCss.mobileNavLinksContainer}>
        {logoLink}
        <MobileNavLinks initial={{ x: "150%", display: "none" }} animate={animation} css={collapseBreakpointCss.mobileNavLinks}>
          {links}
        </MobileNavLinks>
        <NavToggle onClick={toggleNavbar} className={showNavLinks ? "open" : "closed"}>
          {showNavLinks ? <CloseIcon tw="w-6 h-6" /> : <MenuIcon tw="w-6 h-6" />}
        </NavToggle>
      </MobileNavLinksContainer>
    </Header>
  );
};

/* The below code is for generating dynamic break points for navbar.
 * Using this you can specify if you want to switch
 * to the toggleable mobile navbar at "sm", "md" or "lg" or "xl" above using the collapseBreakpointClass prop
 * Its written like this because we are using macros and we can not insert dynamic variables in macros
 */

const collapseBreakPointCssMap = {
  sm: {
    mobileNavLinks: tw`sm:hidden`,
    desktopNavLinks: tw`sm:flex`,
    mobileNavLinksContainer: tw`sm:hidden`
  },
  md: {
    mobileNavLinks: tw`md:hidden`,
    desktopNavLinks: tw`md:flex`,
    mobileNavLinksContainer: tw`md:hidden`
  },
  lg: {
    mobileNavLinks: tw`lg:hidden`,
    desktopNavLinks: tw`lg:flex`,
    mobileNavLinksContainer: tw`lg:hidden`
  },
  xl: {
    mobileNavLinks: tw`lg:hidden`,
    desktopNavLinks: tw`lg:flex`,
    mobileNavLinksContainer: tw`lg:hidden`
  }
};