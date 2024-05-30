import { useParams } from "react-router-dom"
import PostForm from "./PostForm"
import { useEffect, useState } from "react"
import { getPostById } from "../managers/postManager"

const EditPost = () =>
{
    const { postId } = useParams()
    const [post, setPost] = useState()

    useEffect(
        () =>
        {
            getPostById(postId).then(setPost)
        }, [postId]
    )

    return <PostForm initialPost={post} onPostSubmitted={() => {}} />
}

export default EditPost