import React, { useEffect, useState } from "react";
import { Link, useHistory } from "react-router-dom";
import vazioImg from "../../assets/imagem_album_vazio.svg";
import albumImg from "../../assets/imagem_album.svg";
import iconArrow from "../../assets/icon_arrow-down.svg";
import Layout from "../../components/layout";
import api from "../../Api";

function Album() {
  const [albuns, setAlbuns] = useState([]);
  const [loading, setLoading] = useState(true);
  const history = useHistory();

  async function fechData() {
    try {
      const response = await api.get("/api/Album");
      setAlbuns(response.data);
      setLoading(false);
    } catch (err) {
      alert("error get api");
    }
  }

  useEffect(() => {
    fechData();
  },[]);

  return (
    <Layout>
      <div className="row mt-3 align-items-center">
        <div className="col-md-4">
          <h1 className="text-green">Album</h1>
          <p className="fs-5 mt-4">Aqui estão todos os seus albuns.</p>

          
          <button
            onClick={() => {
              history.push("/album/novo");
            }}
            className="btn-create rounded-pill btn-lg border-0 px-4"
          >
            Criar Album
          </button>
        </div>

        <div className="col-md-3">
          <img src={albumImg} alt="imagem inicio" width="778" height="369" />
        </div>
      </div>

      {loading && <p>Loading...</p>}
      {!loading && (
        <div className="row justify-content-center mt-5">
          <div className="col">
            <div className="card">
              <div className="card-header">
                <strong className="card-title">Albuns</strong>
              </div>
              <div className="card-body">
                <table className="table table-striped table-bordered mt-4">
                  <thead>
                    <tr>
                      <th scope="col">Nome</th>
                      <th scope="col">Ano de Lançamento</th>
                      <th></th>
                    </tr>
                  </thead>
                  <tbody>
                    {albuns.map((x) => {
                      return (
                        <tr key={x.albumId}>
                          <td>{x.nome}</td>
                          <td>{x.anoLancamento}</td>
                          <td>
                            <Link
                              to={`/album/consultar/${x.albumId}`}
                              className="btn btn-outline-dark"
                            >
                              Consultar
                            </Link>
                            <Link
                              to={`/album/alterar/${x.albumId}`}
                              className="btn btn-outline-dark mx-3"
                            >
                              Alterar
                            </Link>
                            <Link
                              to={`/album/excluir/${x.albumId}`}
                              className="btn btn-outline-dark mx-3"
                            >
                              Excluir
                            </Link>
                          </td>
                        </tr>
                      );
                    })}
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>
      )}
    </Layout>
  );
}
export default Album;
