import React, { Component } from 'react';
import { ScrollView, View, Image, TextInput, TouchableOpacity, Text } from 'react-native';
import { general, metrics } from 'styles';
import { connect } from 'react-redux';
import { Creators as SignupActions } from 'store/ducks/signup';
import { bindActionCreators } from 'redux';
import styles from './styles';

const img = require('../../res/marca.png');

class Signup extends Component {
  state = {
    email: 'teste',
    name: 'teste',
    username: 'teste',
    password: 'teste',
    passwordCheck: 'teste',
    phone: 'teste',
    document: 'teste',
  }

  doSignup = () => {
    if (!this.state.email || !this.state.name || !this.state.username || !this.state.password || !this.state.document || !this.state.phone) {
      this.setState({ error: 'Favor preencher todos os campos' })
    } else {
      if (this.state.password !== this.state.passwordCheck) {
        this.setState({ error: 'As senhas não conferem' })
      } else {
        this.props.SignupActions.callSignup(this.state.email, this.state.name, this.state.username, this.state.password, this.state.phone, this.state.document)
      }
    }
  }

  render() {
    return (
      <View style={general.container}>
        <View style={styles.header}>
          <Image resizeMode="contain" source={img} style={{width: '80%', height: 150}} />
        </View>
        <View style={styles.body}>
          {this.state.error && <Text style={styles.textError}>{this.state.error}</Text>}
          <ScrollView style={styles.form}>
            <TextInput style={general.input}
              value={this.state.email}
              placeholder="email"
              onChangeText={email => this.setState({ email })}
            />
            <TextInput style={general.input}
              value={this.state.name}
              placeholder="nome"
              onChangeText={name => this.setState({ name })}
            />
            <TextInput style={general.input}
              value={this.state.username}
              placeholder="usuário"
              onChangeText={username => this.setState({ username })}
            />
            <TextInput style={general.input}
              value={this.state.password}
              placeholder="senha"
              onChangeText={password => this.setState({ password })}
            />
            <TextInput style={general.input}
              value={this.state.passwordCheck}
              placeholder="confirme sua senha"
              onChangeText={passwordCheck => this.setState({ passwordCheck })}
            />
            <TextInput style={general.input}
              value={this.state.document}
              placeholder="document"
              onChangeText={document => this.setState({ document })}
            />
            <TextInput style={general.input}
              value={this.state.phone}
              placeholder="celular"
              onChangeText={phone => this.setState({ phone })}
            />
          </ScrollView>
          <Text>{this.props.signup.message}</Text>
          <View style={styles.footer}>
            <TouchableOpacity
              onPress={this.doSignup}
              style={styles.btnSignup}
            >
              { this.props.signup.loading ? 
                <ActivityIndicator color="#000" size={18} />
                : <Text style={styles.textSignup}>Cadastrar</Text>
              }
            </TouchableOpacity>
          </View>
        </View>
      </View>
    );
  }
}

const mapStateToProps = state => ({
  signup: state.signup,
});

const mapDispatchToProps = dispatch => ({
  SignupActions: bindActionCreators(SignupActions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Signup);