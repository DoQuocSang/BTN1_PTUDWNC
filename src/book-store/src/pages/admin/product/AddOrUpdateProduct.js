import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import Book1 from "images/book1.png"
import Book2 from "images/book2.jpg"
import Book3 from "images/book3.jpg"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPenToSquare } from "@fortawesome/free-solid-svg-icons";
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import { faPlus } from "@fortawesome/free-solid-svg-icons";
import { Link } from "react-router-dom";
import { AddOrUpdateText } from "../../../components/utils/Utils";
import { addOrUppdateBook } from "../../../services/BookRepository";
import { getBookById } from "../../../services/BookRepository";
import { getAuthors } from "../../../services/AuthorRepository";
import { getCategories } from "../../../services/CategoryRepository";
import { isEmptyOrSpaces } from "../../../components/utils/Utils";



export default ({ type = "" }) => {

    let mainText = AddOrUpdateText(type, "sản phẩm");
    const initialState = {
        id: 0,
        title: '',
        shortDescription: '',
        Description: '',
        urlSlug: '',
        meta: '',
        imageUrl: '',
        // category: {},
        // author: {},
        authorId: 0,
        categoryId: 0,
        price: 0,
        coverForm: '',
        supplier: '',
        publishCompany: '',
    },
        [book, setBook] = useState(initialState);

    const [categoriesList, setCategoriesList] = useState([]);
    const [authorsList, setAuthorsList] = useState([]);

    let { id } = useParams();
    id = id ?? 0;
    //console.log(id);
    useEffect(() => {
        document.title = "Thêm/ cập nhật sản phẩm";

        getBookById(id).then(data => {
            if (data)
                setBook({
                    ...data
                });
            else
                setBook(initialState);
            console.log(data);
        })

        getAuthors().then(data => {
            if (data) {
                setAuthorsList(data.items);
            }
            else
                setAuthorsList([]);
            //console.log(data.items)
        })

        getCategories().then(data => {
            if (data) {
                setCategoriesList(data.items);
            }
            else
                setCategoriesList([]);
            //console.log(data.items)
        })
    }, [])

    return (
        <div id="main-content" className="h-full w-full bg-gray-50 relative overflow-y-auto lg:ml-64">
            <main>
                <div className="mt-12 px-4">
                    <div className="editor mx-auto flex w-10/12 max-w-2xl flex-col p-6 text-gray-800 shadow-lg mb-12 rounded-lg border-t-4 border-purple-400">
                        <div className="flex mb-4 items-center space-x-5">
                            <div className="h-14 w-14 bg-yellow-200 rounded-full flex flex-shrink-0 justify-center items-center text-yellow-500 text-2xl font-mono">i</div>
                            <div className="block pl-2 font-semibold text-xl self-start text-gray-700">
                                <h2 className="leading-relaxed">{mainText.headingText}</h2>
                                <p className="text-sm text-gray-500 font-normal leading-relaxed">Vui lòng điền vào các ô bên dưới</p>
                            </div>
                        </div>
                        <input
                            name="title"
                            required
                            type="text"
                            value={book.title || ''}
                            onChange={e => setBook({
                                ...book,
                                title: e.target.value,
                                meta: e.target.value
                            })}
                            placeholder="Nhập tên sách"
                            className="text-black mb-4 placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base   transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400" />
                        <input
                            name="slug"
                            required
                            type="text"
                            value={book.urlSlug || ''}
                            onChange={e => setBook({
                                ...book,
                                urlSlug: e.target.value
                            })}
                            placeholder="Nhập định danh slug"
                            className="text-black mb-4 placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base   transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400" />
                        <select
                            name='authorId'
                            value={book.authorId}
                            required
                            onChange={e => {
                                setBook({
                                    ...book,
                                    authorId: e.target.value
                                })
                            }}
                            className=" text-black mb-4 placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400 appearance-none">
                            <option value=''>--- Chọn tác giả ---</option>
                            {authorsList.map((item, index) => (
                                <option key={index} value={item.id}>{item.fullName}</option>
                            ))}
                        </select>
                        <select
                            name='categoryId'
                            value={book.categoryId}
                            required
                            onChange={e => {
                                setBook({
                                    ...book,
                                    categoryId: e.target.value
                                }); console.log(book.categoryId)
                            }}
                            className=" text-black mb-4 placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400 appearance-none">
                            <option value=''>--- Chọn chủ đề ---</option>
                            {categoriesList.map((item, index) => (
                                <option key={index} value={item.id}>{item.name}</option>
                            ))}
                        </select>
                        <textarea
                            name="shortDescription"
                            required
                            type="text"
                            value={book.shortDescription || ''}
                            onChange={e => setBook({
                                ...book,
                                shortDescription: e.target.value
                            })}
                            placeholder="Nhập mô tả ngắn"
                            className="description mb-4 sec h-20 text-black placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400" spellcheck="false"></textarea>
                        <textarea
                            name="description"
                            required
                            type="text"
                            value={book.description || ''}
                            onChange={e => setBook({
                                ...book,
                                description: e.target.value
                            })}
                            placeholder="Nhập mô tả chi tiết"
                            className="description mb-4 sec h-36 text-black placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400" spellcheck="false" ></textarea>

                        <input
                            name="price"
                            required
                            type="text"
                            value={book.price || ''}
                            onChange={e => setBook({
                                ...book,
                                price: e.target.value
                            })}
                            placeholder="Nhập giá sách"
                            className="text-black mb-4 placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base   transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400" />
                        <input
                            name="coverForm"
                            required
                            type="text"
                            value={book.coverForm || ''}
                            onChange={e => setBook({
                                ...book,
                                coverForm: e.target.value
                            })}
                            placeholder="Nhập hình thức bìa"
                            className="text-black mb-4 placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base   transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400" />
                        <input
                            name="supplier"
                            required
                            type="text"
                            value={book.supplier || ''}
                            onChange={e => setBook({
                                ...book,
                                supplier: e.target.value
                            })}
                            placeholder="Nhập nhà cung cấp"
                            className="text-black mb-4 placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base   transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400" />
                        <input
                            name="publishCompany"
                            required
                            type="text"
                            value={book.publishCompany || ''}
                            onChange={e => setBook({
                                ...book,
                                publishCompany: e.target.value
                            })}
                            placeholder="Nhập nhà xuất bản"
                            className="text-black mb-4 placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base   transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400" />

                        <input
                            name="imageUrl"
                            required
                            type="text"
                            value={book.imageUrl || ''}
                            onChange={e => setBook({
                                ...book,
                                imageUrl: e.target.value,
                            })}
                            placeholder="Nhập link ảnh"
                            className="text-black mb-4 placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base   transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400" />

                        {!isEmptyOrSpaces(book.imageUrl) && <>
                            <p className="text-gray-600 mb-4 text-center">Ảnh hiện tại</p>
                            <img src={book.imageUrl} className="w-full h-auto mb-4 rounded-lg" />
                        </>}

                        <div className="buttons flex">
                            <hr className="mt-4" />
                            <Link to="/admin/dashboard/all-product" className="btn ml-auto rounded-md transition duration-300 ease-in-out cursor-pointer hover:bg-gray-500 p-2 px-5 font-semibold hover:text-white text-gray-500">
                                Hủy
                            </Link>
                            <button type="submit" className="btn ml-2 rounded-md transition duration-300 ease-in-out cursor-pointer !hover:bg-indigo-700 !bg-indigo-500 p-2 px-5 font-semibold text-white">
                                {mainText.buttonText}
                            </button>
                        </div>

                    </div>

                </div>
            </main>
        </div>
    );
}
