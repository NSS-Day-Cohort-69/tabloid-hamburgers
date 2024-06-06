import { useContext } from "react"
import { useParams } from "react-router-dom"
import { UserContext } from "../../App"

const UserIsProfile = ({ children }) =>
{
    const user = useContext(UserContext)
    const { id } = useParams()

    return user.id == id || user.roles.some(r => r == "Admin")
        ? <>{children}</>
        : <>You do not own this profile.</>
}

export default UserIsProfile