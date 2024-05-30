import PostForm from "./PostForm"
import { createPostByMe } from "../managers/postManager"

const CreatePost = () =>
{
    const onPostSubmitted = (post) =>
    {
        createPostByMe(post)
    }
    return <PostForm onPostSubmitted={onPostSubmitted} />
}

export default CreatePost