import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getProfile } from "../../managers/userProfileManager";
import { getPostsByUser } from "../../managers/postManager";


export default function UserProfileDetails()
{
  const [userProfile, setUserProfile] = useState();
  const [usersPosts, setUsersPosts] = useState();

  const { id } = useParams();

  useEffect(() =>
  {
    getProfile(id).then(setUserProfile);
    getPostsByUser(id).then(setUsersPosts);
    
  }, [id]);

  if(!userProfile)
  {
    return null;
  }

  const onImageError = () =>
  {
    userProfile.imageLocation = "https://resources.alleghenycounty.us/css/images/Default_No_Image_Available.png"
  }
  return (
    <>

      <img src={userProfile.imageLocation} alt={userProfile.firstName} onError={onImageError} />
      <h3>{userProfile.fullName}</h3>
      <p>Username: {userProfile.userName}</p>
      <p>email: {userProfile.email}</p>
      <p>creation date: {new Date(userProfile.createDateTime).toDateString()}</p>
      <p>{userProfile.roles?.includes("Admin") ? "Admin" : "Author"}</p>
     
      <section >
          {usersPosts?.map((p) => (
           <div key={p.id} className="">
            <h2>{p.title}</h2>
             <img src={p.imageURL}></img>
             <p>{p.content}</p>
             <p>{p.publicationDate}</p>
             <p>{p.author?.firstName}</p>
           </div>
          ))}
        </section>
    </>
  );
}
