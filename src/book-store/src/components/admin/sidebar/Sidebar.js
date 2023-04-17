import React from "react";
import { Link } from "react-router-dom";

export default () => {

   return (
      <>
         <aside id="sidebar" className="fixed hidden z-20 h-full top-0 left-0 pt-16 flex lg:flex flex-shrink-0 flex-col w-64 transition-width duration-75" aria-label="Sidebar">
            <div className="relative flex-1 flex flex-col min-h-0 border-r border-gray-200 bg-white pt-0">
               <div className="flex-1 flex flex-col pt-5 pb-4 overflow-y-auto">
                  <div className="flex-1 px-3 bg-white divide-y space-y-1">
                     <ul className="space-y-2 pb-3 px-3">
                        <li>
                           <form action="#" method="GET" className="lg:hidden">
                              <label for="mobile-search" className="sr-only">Tìm kiếm</label>
                              <div className="relative">
                                 <div className="absolute inset-y-0 left-0 pl-3 flex items-center pointer-events-none">
                                    <svg className="w-5 h-5 text-gray-500" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                       <path d="M5 3a2 2 0 00-2 2v2a2 2 0 002 2h2a2 2 0 002-2V5a2 2 0 00-2-2H5zM5 11a2 2 0 00-2 2v2a2 2 0 002 2h2a2 2 0 002-2v-2a2 2 0 00-2-2H5zM11 5a2 2 0 012-2h2a2 2 0 012 2v2a2 2 0 01-2 2h-2a2 2 0 01-2-2V5zM11 13a2 2 0 012-2h2a2 2 0 012 2v2a2 2 0 01-2 2h-2a2 2 0 01-2-2v-2z"></path>
                                    </svg>
                                 </div>
                                 <input type="text" name="email" id="mobile-search" className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-cyan-600 focus:ring-cyan-600 block w-full pl-10 p-2.5" placeholder="Tìm kiếm" />
                              </div>
                           </form>
                        </li>
                        <li>
                           <Link to="/admin/dashboard">
                              <a className="text-sm text-gray-900 font-semibold rounded-lg flex items-center p-2 hover:bg-gray-100 group">
                                 <svg className="w-6 h-6 text-gray-500 group-hover:text-gray-900 transition duration-75" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M2 10a8 8 0 018-8v8h8a8 8 0 11-16 0z"></path>
                                    <path d="M12 2.252A8.014 8.014 0 0117.748 8H12V2.252z"></path>
                                 </svg>
                                 <span className="ml-3">
                                    Quản lý chung
                                 </span>
                              </a>
                           </Link>
                        </li>
                        <li>
                           <Link to="/admin/dashboard/all-product">
                              <a target="_blank" className="text-sm text-gray-900 font-semibold rounded-lg hover:bg-gray-100 flex items-center p-2 group ">
                                 <svg className="w-6 h-6 text-gray-500 flex-shrink-0 group-hover:text-gray-900 transition duration-75" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M5 3a2 2 0 00-2 2v2a2 2 0 002 2h2a2 2 0 002-2V5a2 2 0 00-2-2H5zM5 11a2 2 0 00-2 2v2a2 2 0 002 2h2a2 2 0 002-2v-2a2 2 0 00-2-2H5zM11 5a2 2 0 012-2h2a2 2 0 012 2v2a2 2 0 01-2 2h-2a2 2 0 01-2-2V5zM11 13a2 2 0 012-2h2a2 2 0 012 2v2a2 2 0 01-2 2h-2a2 2 0 01-2-2v-2z"></path>
                                 </svg>
                                 <span className="ml-3 flex-1 whitespace-nowrap">
                                    Sách
                                 </span>
                                 {/* <span className="bg-gray-200 text-gray-800 ml-3 text-sm font-medium inline-flex items-center justify-center px-2 rounded-full">Pro</span> */}
                              </a>
                           </Link>
                        </li>
                        <li>
                           <a href="#" className="text-sm text-gray-900 font-semibold rounded-lg hover:bg-gray-100 flex items-center p-2 group ">
                              <svg className="w-6 h-6 text-gray-500 flex-shrink-0 group-hover:text-gray-900 transition duration-75" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                 <path fill-rule="evenodd" d="M10 9a3 3 0 100-6 3 3 0 000 6zm-7 9a7 7 0 1114 0H3z" clip-rule="evenodd"></path>
                              </svg>
                              <span className="ml-3 flex-1 whitespace-nowrap">Loại sách</span>
                           </a>
                        </li>
                     </ul>
                     <div className="space-y-2 pt-3 px-3">
                        <a href="#" className="text-sm text-gray-900 font-semibold rounded-lg hover:bg-gray-100 group transition duration-75 flex items-center p-2">
                           <svg className="w-5 h-5 text-gray-500 flex-shrink-0 group-hover:text-gray-900 transition duration-75" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="gem" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
                              <path fill="currentColor" d="M378.7 32H133.3L256 182.7L378.7 32zM512 192l-107.4-141.3L289.6 192H512zM107.4 50.67L0 192h222.4L107.4 50.67zM244.3 474.9C247.3 478.2 251.6 480 256 480s8.653-1.828 11.67-5.062L510.6 224H1.365L244.3 474.9z"></path>
                           </svg>
                           <span className="ml-4">Đăng xuất</span>
                        </a>
                     </div>
                  </div>
               </div>
            </div>
         </aside>
         <div className="bg-gray-900 opacity-50 hidden fixed inset-0 z-10" id="sidebarBackdrop"></div>
      </>
   );
}