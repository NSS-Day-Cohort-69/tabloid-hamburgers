import PostForm from "./PostForm"
import { createPostByMe } from "../managers/postManager"
import { useNavigate } from "react-router-dom"

const CreatePost = () =>
{
    const navigate = useNavigate()

    const onPostSubmitted = (post) =>
    {
        createPostByMe(post).then(
            () => navigate("/post")
        )
    }
    return <PostForm onPostSubmitted={onPostSubmitted} />
}

export default CreatePost