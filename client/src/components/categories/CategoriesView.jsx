import { useEffect, useState } from "react";
import { deleteCategory, getAllCategories } from "../../managers/categories";
import "./Categories.css";
import { useNavigate } from "react-router-dom";

export const CategoriesView = () => {
  const [allCategories, setAllCategories] = useState([]);
  const navigate = useNavigate();

  const getCategories = () => {
    getAllCategories().then(setAllCategories);
  };

  useEffect(() => {
    getCategories();
  }, []);

  return (
    <main>
      <div className="CategoriesView-div-maincontainer">
        <button
          className="CategoriesView-btn-createbutton"
          onClick={() => {
            navigate("create");
          }}
        >
          Create
        </button>
        {allCategories.map((c) => {
          return (
            <article key={c.id}>
              {c.categoryName}
              <button
                onClick={() => {
                  if (window.confirm(`Confirm delete for: ${c.categoryName}`)) {
                    deleteCategory(c.id).then(() => {
                      getCategories();
                    });
                  }
                }}
              >
                Delete
              </button>
            </article>
          );
        })}
      </div>
    </main>
  );
};
