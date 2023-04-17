import React from "react";
import Book1 from "images/book1.png"
import Book2 from "images/book2.jpg"
import Book3 from "images/book3.jpg"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPenToSquare } from "@fortawesome/free-solid-svg-icons";
import { faTrash } from "@fortawesome/free-solid-svg-icons";


export default () => {

    return (
        <div id="main-content" className="h-full w-full bg-gray-50 relative overflow-y-auto lg:ml-64">
            <main>
                <div className="pt-6 px-4">
                    <div className="mb-4 w-full grid grid-cols-1 md:grid-cols-2 xl:grid-cols-3 gap-4">
                        {/* <div className="bg-white shadow rounded-lg p-4 sm:p-6 xl:p-8 bg-rose-400">
                            <div className="flex items-center">
                                <div className="flex-shrink-0">
                                    <span className="text-2xl sm:text-3xl leading-none font-bold text-white">2,340</span>
                                    <h3 className="text-base font-normal text-white">Sản phẩm</h3>
                                </div>
                                <div className="ml-5 w-0 flex items-center justify-end flex-1 text-white text-base font-bold">
                                    <FontAwesomeIcon icon={faPenToSquare} className="text-3xl"/>
                                </div>
                            </div>
                        </div> */}
                        
                        <div className="bg-white shadow rounded-lg p-4 sm:p-6 xl:p-8 ">
                            <div className="flex items-center">
                                <div className="flex-shrink-0">
                                    <span className="text-2xl sm:text-3xl leading-none font-bold text-gray-900">2,355</span>
                                    <h3 className="text-base font-normal text-gray-500">Sản phẩm</h3>
                                </div>
                                {/* <div className="ml-5 w-0 flex items-center justify-end flex-1 text-green-500 text-base font-bold">
                                    32.9%
                                    <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                        <path fill-rule="evenodd" d="M5.293 7.707a1 1 0 010-1.414l4-4a1 1 0 011.414 0l4 4a1 1 0 01-1.414 1.414L11 5.414V17a1 1 0 11-2 0V5.414L6.707 7.707a1 1 0 01-1.414 0z" clip-rule="evenodd"></path>
                                    </svg>
                                </div> */}
                            </div>
                        </div>

                        <div className="bg-white shadow rounded-lg p-4 sm:p-6 xl:p-8 ">
                            <div className="flex items-center">
                                <div className="flex-shrink-0">
                                    <span className="text-2xl sm:text-3xl leading-none font-bold text-gray-900">5,355</span>
                                    <h3 className="text-base font-normal text-gray-500">Còn hàng</h3>
                                </div>
                                {/* <div className="ml-5 w-0 flex items-center justify-end flex-1 text-green-500 text-base font-bold">
                                    32.9%
                                    <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                        <path fill-rule="evenodd" d="M5.293 7.707a1 1 0 010-1.414l4-4a1 1 0 011.414 0l4 4a1 1 0 01-1.414 1.414L11 5.414V17a1 1 0 11-2 0V5.414L6.707 7.707a1 1 0 01-1.414 0z" clip-rule="evenodd"></path>
                                    </svg>
                                </div> */}
                            </div>
                        </div>
                        <div className="bg-white shadow rounded-lg p-4 sm:p-6 xl:p-8 ">
                            <div className="flex items-center">
                                <div className="flex-shrink-0">
                                    <span className="text-2xl sm:text-3xl leading-none font-bold text-gray-900">385</span>
                                    <h3 className="text-base font-normal text-gray-500">Hết hàng</h3>
                                </div>
                                {/* <div className="ml-5 w-0 flex items-center justify-end flex-1 text-red-500 text-base font-bold">
                                    -2.7%
                                    <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
                                        <path fill-rule="evenodd" d="M14.707 12.293a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 111.414-1.414L9 14.586V3a1 1 0 012 0v11.586l2.293-2.293a1 1 0 011.414 0z" clip-rule="evenodd"></path>
                                    </svg>
                                </div> */}
                            </div>
                        </div>
                    </div>

                    <div className="w-full mb-8">
                        <div className="bg-white shadow rounded-lg p-4 sm:p-6 xl:p-8 ">
                            <div className="mb-4 flex items-center justify-between">
                                <div>
                                    <h3 className="text-xl font-bold text-gray-900 mb-2">Quản lý sách</h3>
                                    <span className="text-base font-normal text-gray-500">Các sách hiện có trong database</span>
                                </div>
                                {/* <div className="flex-shrink-0">
                                    <a href="#" className="text-sm font-medium text-cyan-600 hover:bg-gray-100 rounded-lg p-2">View all</a>
                                </div> */}
                            </div>
                            <div className="flex flex-col mt-8">
                                <div className="overflow-x-auto rounded-lg">
                                    <div className="align-middle inline-block min-w-full">
                                        <div className="shadow overflow-hidden sm:rounded-lg">
                                            <table className="min-w-full divide-y divide-gray-200">
                                                <thead className="bg-gray-50">
                                                    <tr>
                                                        <th scope="col" className="p-4 text-center text-sm font-semibold text-gray-500 uppercase tracking-wider">
                                                            Id
                                                        </th>
                                                        <th scope="col" className="p-4 text-left text-sm font-semibold text-gray-500 uppercase tracking-wider">
                                                            Tên sách
                                                        </th>
                                                        <th scope="col" className="p-4 text-left text-sm font-semibold text-gray-500 uppercase tracking-wider">
                                                            Loại sách
                                                        </th>
                                                        <th scope="col" className="p-4 text-left text-sm font-semibold text-gray-500 uppercase tracking-wider">
                                                            Ảnh
                                                        </th>
                                                        <th scope="col" className="p-4 text-left text-sm font-semibold text-gray-500 uppercase tracking-wider">
                                                            Mô tả ngắn
                                                        </th>
                                                        <th scope="col" className="p-4 text-left text-sm font-semibold text-gray-500 uppercase tracking-wider">
                                                            Giá
                                                        </th>
                                                        <th scope="col" className="p-4 text-left text-sm font-semibold text-gray-500 uppercase tracking-wider">
                                                            Sửa
                                                        </th>
                                                        <th scope="col" className="p-4 text-left text-sm font-semibold text-gray-500 uppercase tracking-wider">
                                                            Xóa
                                                        </th>
                                                      
                                                    </tr>
                                                </thead>
                                                <tbody className="bg-white">
                                                    <tr>
                                                        {/* <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            Payment from <span className="font-semibold">Bonnie Green</span>
                                                        </td> */}
                                                        <td className="p-4 whitespace-nowrap text-sm font-bold text-gray-500">
                                                            1
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            <img className="h-40 w-auto rounded-lg" src={Book1} alt="Neil image" />
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-semibold text-gray-900">
                                                            23.000VND
                                                        </td>

                                                        <th scope="col" className="p-4 text-left text-xl font-semibold text-emerald-400 uppercase tracking-wider">
                                                            <FontAwesomeIcon icon={faPenToSquare} />
                                                        </th>
                                                        <th scope="col" className="p-4 text-left text-xl font-semibold text-red-400 uppercase tracking-wider">
                                                            <FontAwesomeIcon icon={faTrash} />
                                                        </th>
                                                    </tr>

                                                    <tr class="bg-gray-50">
                                                        {/* <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            Payment from <span className="font-semibold">Bonnie Green</span>
                                                        </td> */}
                                                        <td className="p-4 whitespace-nowrap text-sm font-bold text-gray-500">
                                                            1
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            <img className="h-40 w-auto rounded-lg" src={Book2} alt="Neil image" />
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-semibold text-gray-900">
                                                            23.000VND
                                                        </td>
                                                        <th scope="col" className="p-4 text-left text-xl font-semibold text-emerald-400 uppercase tracking-wider">
                                                            <FontAwesomeIcon icon={faPenToSquare} />
                                                        </th>
                                                        <th scope="col" className="p-4 text-left text-xl font-semibold text-red-400 uppercase tracking-wider">
                                                            <FontAwesomeIcon icon={faTrash} />
                                                        </th>
                                                    </tr>

                                                    <tr>
                                                        {/* <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            Payment from <span className="font-semibold">Bonnie Green</span>
                                                        </td> */}
                                                        <td className="p-4 whitespace-nowrap text-sm font-bold text-gray-500">
                                                            1
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            <img className="h-40 w-auto rounded-lg" src={Book1} alt="Neil image" />
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-semibold text-gray-900">
                                                            23.000VND
                                                        </td>
                                                        <th scope="col" className="p-4 text-left text-xl font-semibold text-emerald-400 uppercase tracking-wider">
                                                            <FontAwesomeIcon icon={faPenToSquare} />
                                                        </th>
                                                        <th scope="col" className="p-4 text-left text-xl font-semibold text-red-400 uppercase tracking-wider">
                                                            <FontAwesomeIcon icon={faTrash} />
                                                        </th>
                                                    </tr>

                                                    <tr class="bg-gray-50">
                                                        {/* <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            Payment from <span className="font-semibold">Bonnie Green</span>
                                                        </td> */}
                                                        <td className="p-4 whitespace-nowrap text-sm font-bold text-gray-500">
                                                            1
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            <img className="h-40 w-auto rounded-lg" src={Book3} alt="Neil image" />
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-semibold text-gray-900">
                                                            23.000VND
                                                        </td>
                                                        <th scope="col" className="p-4 text-left text-xl font-semibold text-emerald-400 uppercase tracking-wider">
                                                            <FontAwesomeIcon icon={faPenToSquare} />
                                                        </th>
                                                        <th scope="col" className="p-4 text-left text-xl font-semibold text-red-400 uppercase tracking-wider">
                                                            <FontAwesomeIcon icon={faTrash} />
                                                        </th>
                                                    </tr>

                                                    <tr>
                                                        {/* <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            Payment from <span className="font-semibold">Bonnie Green</span>
                                                        </td> */}
                                                        <td className="p-4 whitespace-nowrap text-sm font-bold text-gray-500">
                                                            1
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            <img className="h-40 w-auto rounded-lg" src={Book1} alt="Neil image" />
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-normal text-gray-900">
                                                            None none none
                                                        </td>
                                                        <td className="p-4 whitespace-nowrap text-sm font-semibold text-gray-900">
                                                            23.000VND
                                                        </td>
                                                        <th scope="col" className="p-4 text-left text-xl font-semibold text-emerald-400 uppercase tracking-wider">
                                                            <FontAwesomeIcon icon={faPenToSquare} />
                                                        </th>
                                                        <th scope="col" className="p-4 text-left text-xl font-semibold text-red-400 uppercase tracking-wider">
                                                            <FontAwesomeIcon icon={faTrash} />
                                                        </th>
                                                    </tr>

                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    {/* <div className=" my-4">
                        <div className="bg-white shadow rounded-lg mb-4 p-4 sm:p-6 h-full">
                            <div className="flex items-center justify-between mb-4">
                                <h3 className="text-xl font-bold leading-none text-gray-900">Latest Customers</h3>
                                <a href="#" className="text-sm font-medium text-cyan-600 hover:bg-gray-100 rounded-lg inline-flex items-center p-2">
                                    View all
                                </a>
                            </div>
                            <div className="flow-root">
                                <ul role="list" className="divide-y divide-gray-200">
                                    <li className="py-3 sm:py-4">
                                        <div className="flex items-center space-x-4">
                                            <div className="flex-shrink-0">
                                                <img className="h-8 w-8 rounded-full" src="https://demo.themesberg.com/windster/images/users/neil-sims.png" alt="Neil image" />
                                            </div>
                                            <div className="flex-1 min-w-0">
                                                <p className="text-sm font-medium text-gray-900 truncate">
                                                    Neil Sims
                                                </p>
                                                <p className="text-sm text-gray-500 truncate">
                                                    <a href="/cdn-cgi/l/email-protection" className="__cf_email__" data-cfemail="17727a767e7b57607e7973646372653974787a">[email&#160;protected]</a>
                                                </p>
                                            </div>
                                            <div className="inline-flex items-center text-base font-semibold text-gray-900">
                                                $320
                                            </div>
                                        </div>
                                    </li>
                                    <li className="py-3 sm:py-4">
                                        <div className="flex items-center space-x-4">
                                            <div className="flex-shrink-0">
                                                <img className="h-8 w-8 rounded-full" src="https://demo.themesberg.com/windster/images/users/bonnie-green.png" alt="Neil image" />
                                            </div>
                                            <div className="flex-1 min-w-0">
                                                <p className="text-sm font-medium text-gray-900 truncate">
                                                    Bonnie Green
                                                </p>
                                                <p className="text-sm text-gray-500 truncate">
                                                    <a href="/cdn-cgi/l/email-protection" className="__cf_email__" data-cfemail="d4b1b9b5bdb894a3bdbab0a7a0b1a6fab7bbb9">[email&#160;protected]</a>
                                                </p>
                                            </div>
                                            <div className="inline-flex items-center text-base font-semibold text-gray-900">
                                                $3467
                                            </div>
                                        </div>
                                    </li>
                                    <li className="py-3 sm:py-4">
                                        <div className="flex items-center space-x-4">
                                            <div className="flex-shrink-0">
                                                <img className="h-8 w-8 rounded-full" src="https://demo.themesberg.com/windster/images/users/michael-gough.png" alt="Neil image" />
                                            </div>
                                            <div className="flex-1 min-w-0">
                                                <p className="text-sm font-medium text-gray-900 truncate">
                                                    Michael Gough
                                                </p>
                                                <p className="text-sm text-gray-500 truncate">
                                                    <a href="/cdn-cgi/l/email-protection" className="__cf_email__" data-cfemail="57323a363e3b17203e3933242332257934383a">[email&#160;protected]</a>
                                                </p>
                                            </div>
                                            <div className="inline-flex items-center text-base font-semibold text-gray-900">
                                                $67
                                            </div>
                                        </div>
                                    </li>
                                    <li className="py-3 sm:py-4">
                                        <div className="flex items-center space-x-4">
                                            <div className="flex-shrink-0">
                                                <img className="h-8 w-8 rounded-full" src="https://demo.themesberg.com/windster/images/users/thomas-lean.png" alt="Neil image" />
                                            </div>
                                            <div className="flex-1 min-w-0">
                                                <p className="text-sm font-medium text-gray-900 truncate">
                                                    Thomes Lean
                                                </p>
                                                <p className="text-sm text-gray-500 truncate">
                                                    <a href="/cdn-cgi/l/email-protection" className="__cf_email__" data-cfemail="284d45494144685f41464c5b5c4d5a064b4745">[email&#160;protected]</a>
                                                </p>
                                            </div>
                                            <div className="inline-flex items-center text-base font-semibold text-gray-900">
                                                $2367
                                            </div>
                                        </div>
                                    </li>
                                    <li className="pt-3 sm:pt-4 pb-0">
                                        <div className="flex items-center space-x-4">
                                            <div className="flex-shrink-0">
                                                <img className="h-8 w-8 rounded-full" src="https://demo.themesberg.com/windster/images/users/lana-byrd.png" alt="Neil image" />
                                            </div>
                                            <div className="flex-1 min-w-0">
                                                <p className="text-sm font-medium text-gray-900 truncate">
                                                    Lana Byrd
                                                </p>
                                                <p className="text-sm text-gray-500 truncate">
                                                    <a href="/cdn-cgi/l/email-protection" className="__cf_email__" data-cfemail="a2c7cfc3cbcee2d5cbccc6d1d6c7d08cc1cdcf">[email&#160;protected]</a>
                                                </p>
                                            </div>
                                            <div className="inline-flex items-center text-base font-semibold text-gray-900">
                                                $367
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div> */}
                </div>
            </main>

        </div>
    );
}
