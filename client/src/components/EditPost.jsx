import { useNavigate, useParams } from "react-router-dom"
import PostForm from "./PostForm"
import { useEffect, useState } from "react"
import { editPost, getPostById } from "../managers/postManager"

const EditPost = () =>
{
    const { postId } = useParams()
    const [post, setPost] = useState()

    const navigate = useNavigate()

    useEffect(
        () =>
        {
            getPostById(postId).then(setPost)
        }, [postId]
    )

    const onPostSubmitted = (putPost) =>
    {
        putPost.authorId = post.authorId
        editPost(putPost, postId).then(
            () => navigate("/post")
        )
    }

    return <PostForm initialPost={post} onPostSubmitted={onPostSubmitted} />
}

export default EditPost