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

import { AddOrUpdateText, isEmptyOrSpaces } from "../../../components/utils/Utils";
 import { getAuthorById } from "../../../services/AuthorRepository";
import { addOrUpdateAuthor } from "../../../services/AuthorRepository";

export default  ({ type = "" }) => {

    let mainText = AddOrUpdateText(type, "tác giả");
    const initialState = {
        id: 0,
        fullName: '',
        email: '',
        urlSlug: '',
        imageUrl:'',
    },
    [author, setAuthor] = useState(initialState);

    let { id } = useParams();
    id = id ?? 0;
    //console.log(id);
    useEffect(() => {
        document.title = "Thêm/ cập nhật tác giả";

        getAuthorById(id).then(data => {
            if (data)
                    setAuthor({
                    ...data,
                });
            else
                setAuthor(initialState);
            console.log(data);
        })
    }, [])

    const handleSubmit = (e) => {
        e.preventDefault();
        let form = new FormData(e.target);
            addOrUpdateAuthor(form).then(data => {
            if (data)
                alert("Lưu thành công");
            else
                alert("Lỗi");
            console.log(data);
        });
    }

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
                            name="fullName"
                            required
                            type="text"
                            value={author.fullName || ''}
                            onChange={e => setAuthor({
                                ...author,
                                fullName: e.target.value
                            })}
                            placeholder="Nhập tên tác giả"
                            className="text-black mb-4 placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base   transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400" />
                         <input
                            name="urlSlug"
                            required
                            type="text"
                            value={author.urlSlug || ''}
                            onChange={e => setAuthor({
                                ...author,
                                urlSlug: e.target.value
                            })}
                            placeholder="Nhập định danh slug"
                            className="text-black mb-4 placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base   transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400" />
                         <input
                            name="urlSlug"
                            required
                            type="text"
                            value={author.email || ''}
                            onChange={e => setAuthor({
                                ...author,
                                email: e.target.value
                            })}
                            placeholder="Nhập email"
                            className="text-black mb-4 placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base   transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400" />
                        <input
                            name="imageUrl"
                            required
                            type="text"
                            value={author.imageUrl || ''}
                            onChange={e => setAuthor({
                                ...author,
                                imageUrl: e.target.value,
                            })}
                            placeholder="Nhập link ảnh"
                            className="text-black mb-4 placeholder-gray-600 w-full px-4 py-2.5 mt-2 text-base   transition duration-500 ease-in-out transform border-transparent rounded-lg bg-gray-200  focus:border-blueGray-500 focus:bg-white dark:focus:bg-gray-800 focus:outline-none focus:shadow-outline focus:ring-1 ring-offset-current ring-offset-2 ring-purple-400" />
                        {!isEmptyOrSpaces(author.imageUrl) && <>
                       
                        <p className="text-gray-600 mb-4 text-center">Ảnh hiện tại</p>
                        <img src={author.imageUrl} className="w-full h-auto mb-4 rounded-lg" />
                        </>}

                        <div className="buttons flex">
                            <hr className="mt-4" />
                            <Link to="/admin/dashboard/all-author" className="btn ml-auto rounded-md transition duration-300 ease-in-out cursor-pointer hover:bg-gray-500 p-2 px-5 font-semibold hover:text-white text-gray-500">
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
